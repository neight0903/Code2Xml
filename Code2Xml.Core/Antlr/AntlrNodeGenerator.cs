﻿#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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

using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.XmlToCodes;
using Paraiba.Linq;

namespace Code2Xml.Core.Antlr {
    /// <summary>
    ///   Generates a XElement object as a node of syntax tree generated by ANTLR.
    /// </summary>
    public static class AntlrNodeGenerator {
        /// <summary>
        ///   Generates a XElement object as a node representing a block element.
        /// </summary>
        /// <typeparam name="T"> The type of syntax-tree generator. </typeparam>
        /// <param name="node"> The XElement as the node which is supplemented block. </param>
        /// <param name="codeToXml"> </param>
        /// <param name="leftToken"> </param>
        /// <param name="rightToken"> </param>
        /// <returns> </returns>
        public static XElement GenerateBlock<T>(
                XElement node,
                AntlrCodeToXml<T> codeToXml,
                string leftToken = "{",
                string rightToken = "}")
                where T : Parser, IAntlrParser {
            Contract.Requires(node != null);
            Contract.Requires(codeToXml != null);
            Contract.Requires(leftToken != null);
            Contract.Requires(rightToken != null);
            Contract.Ensures(Contract.Result<XElement>() != null);
            return GenerateBlock(
                    node, codeToXml, DefaultXmlToCode.Instance, leftToken,
                    rightToken);
        }

        public static XElement GenerateBlock<T>(
                XElement node,
                AntlrCodeToXml<T> codeToXml,
                XmlToCode xmlToCode,
                string leftToken = "{",
                string rightToken = "}")
                where T : Parser, IAntlrParser {
            Contract.Requires(node != null);
            Contract.Requires(codeToXml != null);
            Contract.Requires(xmlToCode != null);
            Contract.Requires(leftToken != null);
            Contract.Requires(rightToken != null);
            Contract.Ensures(Contract.Result<XElement>() != null);
            var code = xmlToCode.Generate(node);
            if (code.StartsWith(leftToken)) {
                return node;
            }
            var newNode = codeToXml.Generate(
                    leftToken + code + rightToken,
                    node.Name.LocalName);

            var oldTokenNodes = node.Descendants()
                    .Where(e => e.Name.LocalName.All(char.IsUpper));
            var newTokenNodes = newNode.Descendants()
                    .Where(e => e.Name.LocalName.All(char.IsUpper));

            newTokenNodes.First().RemoveAttributes();
            newTokenNodes.Last().RemoveAttributes();

            foreach (var t in oldTokenNodes.Zip(newTokenNodes.Skip(1))) {
                foreach (var attribute in t.Item1.Attributes()) {
                    t.Item2.SetAttributeValue(attribute.Name, attribute.Value);
                }
            }
            return newNode;
        }

        public static XElement GenerateWrappedNode<T>(
                XElement node,
                AntlrCodeToXml<T> codeToXml,
                XmlToCode xmlToCode,
                string beforeCode,
                string afterCode)
                where T : Parser, IAntlrParser {
            Contract.Requires(node != null);
            Contract.Requires(codeToXml != null);
            Contract.Requires(xmlToCode != null);
            Contract.Requires(beforeCode != null);
            Contract.Requires(afterCode != null);
            Contract.Ensures(Contract.Result<XElement>() != null);
            var oldcode = xmlToCode.Generate(node);
            var code = beforeCode + oldcode + afterCode;
            return codeToXml.Generate(code, node.Name.LocalName);
        }

        public static XElement GenerateWrappedNode<T>(
                XElement node,
                AntlrCodeToXml<T> codeToXml,
                XmlToCode xmlToCode,
                string beforeCode,
                string centerCode,
                string afterCode)
                where T : Parser, IAntlrParser {
            Contract.Requires(node != null);
            Contract.Requires(codeToXml != null);
            Contract.Requires(xmlToCode != null);
            Contract.Requires(beforeCode != null);
            Contract.Requires(afterCode != null);
            Contract.Ensures(Contract.Result<XElement>() != null);
            var oldcode = xmlToCode.Generate(node);
            var code = beforeCode + oldcode + centerCode + oldcode + afterCode;
            return codeToXml.Generate(code, node.Name.LocalName);
        }
    }
}