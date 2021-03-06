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
using System.Linq;
using System.Numerics;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    internal class LearningExperimentUtil {
        public static string GetCommonSuffix(string s1, string s2) {
            var count = Math.Min(s1.Length, s2.Length);
            var ret = "";
            var lastIndex = -1;
            for (int i = 0; i < count; i++) {
                var ch = s1[i];
                if (ch == s2[i]) {
                    ret += ch;
                } else {
                    break;
                }
                if (ch == '>') {
                    lastIndex = i;
                }
            }
            return ret.Substring(0, lastIndex + 1);
        }

        public static IEnumerable<string> FindGoodNodeNames(ICollection<CstNode> uppermosts) {
            var name2Count = new Dictionary<string, int>();
            var name2Ids = new Dictionary<string, HashSet<string>>();
            var candidates = uppermosts.SelectMany(
                    e => e.DescendantsOfSingleAndSelf());
            foreach (var e in candidates) {
                if (name2Count.ContainsKey(e.Name)) {
                    name2Count[e.Name] += 1;
                    name2Ids[e.Name].Add(e.NameAndTokenWithId());
                } else {
                    name2Count[e.Name] = 1;
                    name2Ids[e.Name] = new HashSet<string> {
                        e.NameAndTokenWithId()
                    };
                }
            }
            return uppermosts.Select(
                    e => e.DescendantsOfSingleAndSelf()
                            .Select(e2 => e2.Name)
                            .MaxElementOrDefault(
                                    name => (name2Count[name] << 8) + name2Ids[name].Count));
        }

        public static IEnumerable<string> GetFeatureStringsByVector(IDictionary<string, BigInteger> featureString2Bit, BigInteger vector) {
            var featureBit = BigInteger.One;
            while (vector != BigInteger.Zero) {
                if ((vector & featureBit) != BigInteger.Zero) {
                    vector ^= featureBit;
                }
                yield return featureString2Bit.First(kv => kv.Value == featureBit).Key;
                featureBit <<= 1;
            }
        }

	    public static int CountBits(BigInteger bits) {
		    var count = 0;
		    while (bits != BigInteger.Zero) {
			    count += (int)(bits & BigInteger.One);
			    bits >>= 1;
		    }
		    return count;
	    }

	    public static bool IsAccepted(BigInteger feature, BigInteger acceptingClassifier) {
		    return (feature & acceptingClassifier) == acceptingClassifier;
	    }

	    public static bool IsRejected(BigInteger feature, BigInteger rejectingClassifier) {
		    return (feature & rejectingClassifier) != BigInteger.Zero;
	    }

	    public static int CountAcceptingBits(BigInteger bits, BigInteger acceptingFeatureMask) {
		    return CountBits(bits & acceptingFeatureMask);
	    }

	    public static int CountRejectingBits(BigInteger bits, int acceptingFeatureCount) {
		    return CountBits(bits >> acceptingFeatureCount);
	    }
    }
}