﻿#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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

using System.IO;
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Position;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.Java.XmlToCodes;
using NUnit.Framework;
using Paraiba.Xml;

namespace Code2Xml.Languages.Java.Tests {
	[TestFixture]
	public class JavaCodeToXmlTest {
		[Test]
		public void Hudsonのソースコードをパースできる() {
			var path = Fixture.GetInputPath("Java", "FileSystemProvisioner.java");
			JavaCodeToXml.Instance.GenerateFromFile(path, true);
		}

		[Test, ExpectedException(typeof(MismatchedTokenException))]
		public void 不正なユニコード文字の入ったコードをパースできない() {
			var path = Path.Combine(Fixture.GetFailedInputPath("Java"), "Unicode.java");
			JavaCodeToXml.Instance.GenerateFromFile(path, true);
		}

		[Test]
		public void ParseComment() {
			var e = JavaCodeToXml.Instance.Generate(
					@"public class A { /*a
aa*/
/* aaa */
// sss
// bbb
}");
			var cs = e.Descendants("Comment").ToList();
			var p1 = CodePosition.Analyze(cs[0]);
			var p2 = CodePosition.Analyze(cs[1]);
			var p3 = CodePosition.Analyze(cs[2]);
			var p4 = CodePosition.Analyze(cs[3]);
			Assert.That(cs.Count, Is.EqualTo(4));
			Assert.That(p1.StartLine, Is.EqualTo(1));
			Assert.That(p1.EndLine, Is.EqualTo(2));
			Assert.That(p2.StartLine, Is.EqualTo(3));
			Assert.That(p2.EndLine, Is.EqualTo(3));
			Assert.That(p3.StartLine, Is.EqualTo(4));
			Assert.That(p3.EndLine, Is.EqualTo(4));
			Assert.That(p4.StartLine, Is.EqualTo(5));
			Assert.That(p4.EndLine, Is.EqualTo(5));
		}

		[Test]
		public void InterConvertJapanese() {
			var code = @"
@Retention(RetentionPolicy.CLASS)
@Target({
    ElementType.ANNOTATION_TYPE,
    ElementType.CONSTRUCTOR,
    ElementType.FIELD,
    ElementType.METHOD,
    ElementType.TYPE})
@Documented
@GwtCompatible
public @interface Beta {}";
			var r1 = JavaCodeToXml.Instance.Generate(code, true);
			var c1 = JavaXmlToCode.Instance.Generate(r1);
			var r2 = JavaCodeToXml.Instance.Generate(c1, true);
			var c2 = JavaXmlToCode.Instance.Generate(r2);
			var r3 = JavaCodeToXml.Instance.Generate(c2, true);
			var c3 = JavaXmlToCode.Instance.Generate(r3);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.AreEqual(c2, c3);
		}
	}
}