﻿#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core {
    public static class Inference {
        public static HashSet<string> GetSurroundingKeys(
                this CstNode node, int length, bool inner = true, bool outer = true) {
            //inner = outer = true; // TODO: for debug

            var ret = new HashSet<string>();
            var childElements = new List<Tuple<CstNode, string>>();
            if (inner) {
                childElements.Add(Tuple.Create(node, node.Name));
                var ancestorStr = "";
                foreach (var e in node.AncestorsWithSingleChildAndSelf()) {
                    ancestorStr = ancestorStr + "<" + e.NameWithId();
                    ret.Add(ancestorStr);
                }
            }
            var i = 1;
            if (outer) {
                var parentElement = Tuple.Create(node, node.Name);
                var descendantStr = "";
                foreach (var e in node.DescendantsOfSingleAndSelf()) {
                    descendantStr = descendantStr + "<" + e.NameWithId();
                    ret.Add(descendantStr);
                }
                // 自分自身の位置による区別も考慮する
                ret.Add(node.NameAndTokenWithId());
                for (; i <= length; i++) {
                    var newChildElements = new List<Tuple<CstNode, string>>();
                    foreach (var t in childElements) {
                        foreach (var e in t.Item1.Children()) {
                            var key = t.Item2 + ">" + e.NameAndTokenWithId();
                            newChildElements.Add(Tuple.Create(e, key));
                            // トークンが存在するかチェックする弱い条件
                            // for Preconditions.checkArguments()
                            ret.Add(t.Item2 + ">'" + e.TokenText + "'");
                        }
                        foreach (var e in t.Item1.Descendants()) {
                            // トークンが存在するかチェックする弱い条件
                            //ret.Add(t.Item2 + ">>'" + e.TokenText() + "'");
                        }
                    }
                    foreach (var e in parentElement.Item1.Siblings(10)) {
                        var key = parentElement.Item2 + "-" + e.NameAndTokenWithId();
                        newChildElements.Add(Tuple.Create(e, key));
                        // トークンが存在するかチェックする弱い条件
                        // for Preconditions.checkArguments()
                        ret.Add(parentElement.Item2 + "-'" + e.TokenText + "'");
                        //// 先祖に存在するかチェックする弱い条件
                        //var iLastName = parentElement.Item2.LastIndexOf("<");
                        //var weakKey = "<<" + parentElement.Item2.Substring(iLastName + 1) + "-" + e.NameAndTokenWithId();
                        //newChildElements.Add(Tuple.Create(e, weakKey));
                    }
                    ret.UnionWith(newChildElements.Select(t => t.Item2));
                    childElements = newChildElements;

                    var newParentElement = parentElement.Item1.Parent;
                    if (newParentElement == null) {
                        break;
                    }
                    parentElement = Tuple.Create(
                            newParentElement,
                            parentElement.Item2 + "<" + newParentElement.NameAndTokenWithId());
                    ret.Add(parentElement.Item2);
                }
            }
            for (; i <= length; i++) {
                var newChildElements = new List<Tuple<CstNode, string>>();
                foreach (var t in childElements) {
                    foreach (var e in t.Item1.Children()) {
                        var key = t.Item2 + ">" + e.NameAndTokenWithId();
                        newChildElements.Add(Tuple.Create(e, key));
                        // トークンが存在するかチェックする弱い条件
                        // for Preconditions.checkArguments()
                        ret.Add(t.Item2 + ">'" + e.TokenText + "'");
                    }
                }
                ret.UnionWith(newChildElements.Select(t => t.Item2));
                childElements = newChildElements;
            }
            return ret;
        }

        public static HashSet<string> GetUnionKeys(
                this IEnumerable<CstNode> elements, int length, bool inner = true, bool outer = true) {
            var commonKeys = new HashSet<string>();
            foreach (var element in elements) {
                var keys = element.GetSurroundingKeys(length, inner, outer);
                commonKeys.UnionWith(keys);
            }
            return commonKeys;
        }

        public static HashSet<string> GetCommonKeys(
                this IEnumerable<CstNode> elements, int length, bool inner = true, bool outer = true) {
            HashSet<string> commonKeys = null;
            foreach (var element in elements) {
                var keys = element.GetSurroundingKeys(length, inner, outer);
                if (commonKeys == null) {
                    commonKeys = keys;
                } else {
                    commonKeys.IntersectWith(keys);
                }
            }
            return commonKeys;
        }

        public struct LocationInfo {
            public FileInfo FileInfo;
            public CodeRange CodeRange;
        }

        private static ISet<string> AdoptNodeNames(ICollection<CstNode> outermosts) {
            var name2Count = new Dictionary<string, int>();
            var candidates = outermosts.SelectMany(
                    e => e.DescendantsOfSingleAndSelf());
            foreach (var e in candidates) {
                var count = name2Count.GetValueOrDefault(e.Name);
                name2Count[e.Name] = count + 1;
            }
            return outermosts.Select(
                    e => e.DescendantsOfSingleAndSelf()
                            .Select(e2 => e2.Name)
                            .MaxElementOrDefault(name => name2Count[name]))
                    .ToHashSet();
        }

        public static IEnumerable<Tuple<int, LocationInfo>> GetSimilarElements(
                CstGenerator cstGenerator, IEnumerable<LocationInfo> locations,
                IEnumerable<FileInfo> targets,
                int range = 5, bool inner = true, bool outer = true) {
            var path2Ast = new Dictionary<string, CstNode>();
            var paths = locations.Select(l => l.FileInfo).Concat(targets)
                    .Select(f => f.FullName)
                    .ToHashSet();
            foreach (var path in paths) {
                path2Ast.Add(path, cstGenerator.GenerateTreeFromCodePath(path));
            }

            var elements = new List<CstNode>();
            foreach (var location in locations) {
                var root = path2Ast[location.FileInfo.FullName];
                elements.Add(location.CodeRange.FindOutermostElement(root));
            }
            var names = AdoptNodeNames(elements);

            var candidates = new Dictionary<string, IEnumerable<CstNode>>();
            foreach (var keyAndValue in path2Ast) {
                candidates.Add(
                        keyAndValue.Key,
                        keyAndValue.Value.Descendants()
                                .Where(e => names.Contains(e.Name)));
            }
            var commonKeys = elements.GetCommonKeys(range, true, true);
            return candidates.SelectMany(
                    kv => {
                        var fileInfo = new FileInfo(kv.Key);
                        return kv.Value.Select(
                                e => Tuple.Create(
                                        e.GetSurroundingKeys(range, inner, outer)
                                                .Count(commonKeys.Contains),
                                        e))
                                .Select(
                                        t => Tuple.Create(
                                                t.Item1, new LocationInfo {
                                                    FileInfo = fileInfo,
                                                    CodeRange = CodeRange.Locate(t.Item2),
                                                }));
                    })
                    .OrderByDescending(t => t.Item1);
        }
    }
}