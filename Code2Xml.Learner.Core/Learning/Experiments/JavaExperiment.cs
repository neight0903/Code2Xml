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
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    [TestFixture]
    public class JavaExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.JavaUsingAntlr3;

        private const string LangName = "Java";

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                    @"29811229c3ba3da390b29353875be2c92f88a789"),
            Tuple.Create(
                    @"https://github.com/github/android.git",
                    @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee"),
            Tuple.Create(
                    @"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                    @"8cd549f23f3d20ff920e19a2345c54983f65e26b"),
            Tuple.Create(
                    @"https://github.com/loopj/android-async-http.git",
                    @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c"),
            Tuple.Create(
                    @"https://github.com/junit-team/junit.git",
                    @"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8"),
            Tuple.Create(
                    @"https://github.com/square/picasso.git",
                    @"e0c3d44f53919742a0a608277be26b47742bb2a2"),
            Tuple.Create(
                    @"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                    @"65d4183994eaf8c450e81afadb389fca61499063"),
            Tuple.Create(
                    @"https://github.com/cyrilmottier/GreenDroid.git",
                    @"abd9769f677bb4a753f0bf1119f961187bdf7020"),
            Tuple.Create(
                    @"https://github.com/dropwizard/metrics.git",
                    @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28"),
            Tuple.Create(
                    @"https://github.com/nicolasgramlich/AndEngine.git",
                    @"720897f99d2c56ba357e8fe361454bd8d88c37ed"),
            Tuple.Create(
                    @"https://github.com/Prototik/HoloEverywhere.git",
                    @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9"),
            Tuple.Create(
                    @"https://github.com/fernandezpablo85/scribe-java.git",
                    @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b"),
            Tuple.Create(
                    @"https://github.com/LMAX-Exchange/disruptor.git",
                    @"1072645ad75f8b07b9145197fd4137fcfa79011a"),
            Tuple.Create(
                    @"https://github.com/dropwizard/dropwizard.git",
                    @"4758ac698ff9993879798db338b3314c6a1c6a27"),
            Tuple.Create(
                    @"https://github.com/square/retrofit.git",
                    @"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710"),
            Tuple.Create(
                    @"https://github.com/SimonVT/android-menudrawer.git",
                    @"1260f2f6d50d3b572ebfa98e93a0b4f8258371de"),
            Tuple.Create(
                    @"https://github.com/square/dagger.git",
                    @"21a9e0d875da31306b0f41273348f4f75741fef7"),
            Tuple.Create(
                    @"https://github.com/Atmosphere/atmosphere.git",
                    @"dd2397e03088f2bced1f8e47f8f81e935664a923"),
            Tuple.Create(
                    @"https://github.com/thinkaurelius/titan.git",
                    @"c26cd982b1dc5ba792ee7a63af59887bd8b08223"),
            Tuple.Create(
                    @"https://github.com/Comcast/FreeFlow.git",
                    @"47bfb57e8037eecae320266cb00dd23e673362e5"),
            Tuple.Create(
                    @"https://github.com/greenrobot/greenDAO.git",
                    @"d13a1f1d0e8d244e8033a944599adda7bb157bef"),
            Tuple.Create(
                    @"https://github.com/commonsguy/cw-advandroid.git",
                    @"ab8e52a00413592b99a7bb9f93050bee760f289f"),
            Tuple.Create(
                    @"https://github.com/koush/AndroidAsync.git",
                    @"09c60732944a20eac52301026e9c24344ccb3062"),
            Tuple.Create(
                    @"https://github.com/square/android-times-square.git",
                    @"2bb367039b3cb93e6764e55835dc023df9f4fd77"),
            Tuple.Create(
                    @"https://github.com/pardom/ActiveAndroid.git",
                    @"bd98740d466249fc085311b1c166570cfc08f532"),
            Tuple.Create(
                    @"https://github.com/kevinsawicki/http-request.git",
                    @"c11e2a8b335d43adb9e273412ec7a39c7e404e72"),
            Tuple.Create(
                    @"https://github.com/qii/weiciyuan.git",
                    @"14fdfe9f6f7f3d927a66d802b709f53ba0ff629e"),
            Tuple.Create(
                    @"https://github.com/twitter/ambrose.git",
                    @"9ff6dc68e6eb7e95645878082774f44acca5814f"),
            Tuple.Create(
                    @"https://github.com/perwendel/spark.git",
                    @"f1f06769abacc6732e511774d4db2306cbe5db54"),
            Tuple.Create(
                    @"https://github.com/addthis/stream-lib.git",
                    @"56c48e001341f874c37e0113c09554436e93ea10"),
            Tuple.Create(
                    @"https://github.com/http-kit/http-kit.git",
                    @"7184fa8cf2526a24446e7e6602bc16d9d1c0948a"),
            Tuple.Create(
                    @"https://github.com/quartzjer/TeleHash.git",
                    @"133f4212666911d066f59255e2e7fbd69bea8265"),
            Tuple.Create(
                    @"https://github.com/cucumber/cucumber-jvm.git",
                    @"08e6b87a0a21010bf35d643157b7032a40832efd"),
            Tuple.Create(
                    @"https://github.com/jankotek/MapDB.git",
                    @"c890d8b4edc5fb9d064bb04aa132aea8608f87dd"),
            Tuple.Create(
                    @"https://github.com/peter-lawrey/Java-Chronicle.git",
                    @"6716f0cff0750d125a07eb769bba0698a617b7fb"),
            Tuple.Create(
                    @"https://github.com/TooTallNate/Java-WebSocket.git",
                    @"7c3b223536dc8bd4e8794ac265ad06679583e30f"),
            Tuple.Create(
                    @"https://github.com/derekbrameyer/android-betterpickers.git",
                    @"0a72367b478970b1731822e78790a158a4f7ebb4"),
            Tuple.Create(
                    @"https://github.com/typesafehub/config.git",
                    @"36c1392028c82db2c146ade29a2f6940bc6f5407"),
            Tuple.Create(
                    @"https://github.com/OpenTSDB/opentsdb.git",
                    @"a2bd5737d9d11a8fd3fa6e9c36a31dd8cb5c4af4"),
            Tuple.Create(
                    @"https://github.com/kevinweil/elephant-bird.git",
                    @"ccddfc68e634fea2d05a1804057a1c4826817471"),
            Tuple.Create(
                    @"https://github.com/nathanmarz/storm-starter.git",
                    @"917a4c5c171009af3b130d09339355f6310a2042"),
            Tuple.Create(
                    @"https://github.com/mongodb/mongo-hadoop.git",
                    @"29788439cbc8cc9a45910ceba316a70049a8b4e8"),
            Tuple.Create(
                    @"https://github.com/harism/android_page_curl.git",
                    @"7a2c8f152bb4f1b0de3b1aa72b3cb79e1fe8e3bd"),
            Tuple.Create(
                    @"https://github.com/RobotiumTech/robotium.git",
                    @"ee7d989c95f2cf380935f7a117d7f9345820cbf7"),
            Tuple.Create(
                    @"https://github.com/hector-client/hector.git",
                    @"0c760d9347ebf9bdaeec5fe195f175f674590909"),
            Tuple.Create(
                    @"https://github.com/eishay/jvm-serializers.git",
                    @"3ec217ec19aff74654b40a47c010d57a44996efb"),
            Tuple.Create(
                    @"https://github.com/jberkel/sms-backup-plus.git",
                    @"3565f645126d3f9e8c0371ec57c8aac4bbf5cde1"),
            Tuple.Create(
                    @"https://github.com/jayway/maven-android-plugin.git",
                    @"2ce1428c8e83365c5ac096b7855e71bd8a035013"),
            Tuple.Create(
                    @"https://github.com/square/spoon.git",
                    @"975dacb45607ed45492fa3dd9e697f0a5263e71a"),
        };

        private static readonly LearningExperiment[] Experiments = {
            new JavaComplexStatementExperiment(),
            new JavaSuperComplexBranchExperiment(),
            new JavaExpressionStatementExperiment(),
            new JavaArithmeticOperatorExperiment(),
            new JavaSwitchCaseExperiment(),
            new JavaSuperComplexBranchExperimentWithSwitch(),
            new JavaSuperComplexBranchExperimentWithSwitchWithoutTrue(),

            //new JavaComplexBranchExperiment(),
            //new JavaIfExperiment(),
            //new JavaWhileExperiment(),
            //new JavaDoWhileExperiment(),
            //new JavaForExperiment(),
            //new JavaPreconditionsExperiment(),
            //new JavaStatementExperiment(),
            //new JavaBlockExperiment(),
            //new JavaLabeledStatementExperiment(),
            //new JavaEmptyStatementExperiment(),
        };

        protected override string SearchPattern {
            get { return "*.java"; }
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                foreach (var exp in Experiments) {
                    foreach (var learningSet in LearningSets.Skip(SkipCount).Take(TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", url + "Clone\r\n");
                        Git.Clone(path, url);
                        Git.Checkout(path, learningSet.Item2);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", "Done\r\n");
                        yield return new TestCaseData(exp, path);
                    }
                }
            }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java"), };
            Learn(seedPaths, exp, projectPath);
        }

        public void CalculateMetrics(LearningExperiment exp, string projectPath, int starCount) {
            if (!(exp is JavaSuperComplexBranchExperiment)) {
                return;
            }
            var allPaths =
                    Directory.GetFiles(projectPath, SearchPattern, SearchOption.AllDirectories)
                            .ToList();
            var allNodes = allPaths.Select(p => Generator.GenerateTreeFromCodePath(p))
                    .SelectMany(r => r.DescendantsAndSelf());
            var statementCount = 0;
            var branchCount = 0;
            foreach (var node in allNodes) {
                if (node.Name == "statement") {
                    switch (node.FirstChild.TokenText) {
                    case "if":
                    case "while":
                    case "do":
                    case "switch":
                        branchCount++;
                        break;
                    }
                } else if (node.Name == "conditionalExpression" && node.Children().Skip(1).Any()) {
                    branchCount++;
                } else if (node.Name == "switchLabel" && node.FirstChild.TokenText == "case") {
                    branchCount++;
                } else if (node.Name == "statement" || node.Name == "localVariableDeclarationStatement") {
                    statementCount++;
                }
            }
            var writer = Writers[exp.GetType().Name];
            writer.Write(statementCount + ",");
            writer.Write(branchCount + ",");
            writer.WriteLine();
            writer.Flush();
        }
    }

    public class JavaSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                //if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
                //	return false;
                //}
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                //if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
                //	return false;
                //}
                //if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
                //	return false;
                //}
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<CstNode> SelectBooleanExpressions(CstNode e) {
            var expressions = e.Descendants("expression")
                    .Where(
                            e_ => IsIf(e_) || IsWhile(e_) ||
                                  IsDoWhile(e_) || IsFor(e_) || IsCheckArgument(e_))
                    .Where(e_ => !IsChild(e_, IsCatchBlock));
            return expressions;
        }

        public bool IsCatchBlock(CstNode e) {
            // catch { .. snip .. } 
            return e.Name == "block" && e.Parent.Name == "catchClause";
        }

        public bool IsChild(CstNode e, Func<CstNode, bool> isCatchBlock) {
            return e.Ancestors().Any(isCatchBlock);
        }

        public bool IsIf(CstNode e) {
            // if (cond) { .. snip .. }
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "if";
        }

        public bool IsWhile(CstNode e) {
            // while (cond) { .. snip .. }
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "while";
        }

        public bool IsDoWhile(CstNode e) {
            // do { .. snip .. } while (cond);
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "do";
        }

        public bool IsFor(CstNode e) {
            // do { .. snip .. } while (cond);
            var p = e.Parent;
            return p.Name == "forstatement"
                   && p.Elements().Count(e_ => e_.TokenText == ";") >= 2;
        }

        public bool IsCheckArgument(CstNode e) {
            // Preconditions.checkArgument(cond, msg);
            var primary = e.Parent.Parent.Parent.Parent;
            return primary.Name == "primary"
                   && primary.Elements().Any(e2 => e2.TokenText == "checkArgument")
                   && e.ElementsBeforeSelf().Count() == 0;
        }
    }

    public class JavaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            return false;
        }
    }

    public class JavaIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaIfExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            return false;
        }
    }

    public class JavaWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaWhileExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            return false;
        }
    }

    public class JavaDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaDoWhileExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            return false;
        }
    }

    public class JavaForExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaForExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            return false;
        }
    }

    public class JavaPreconditionsExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaPreconditionsExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
            if (primary.SafeName() != "primary") {
                return false;
            }
            //if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
            //	return false;
            //}
            if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                return false;
            }
            //if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
            //	return false;
            //}
            //if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
            //	return false;
            //}
            if (e.ElementsBeforeSelf().Any()) {
                return false;
            }
            return true;
        }
    }

    public class JavaComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaComplexStatementExperiment() : base("statement", "blockStatement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // blockStatement 
            //    :   localVariableDeclarationStatement
            //    |   classOrInterfaceDeclaration
            //    |   statement
            //    ;
            if (e.Name == "blockStatement") {
                if (e.FirstChild.Name != "statement") {
                    return true;
                }
                e = e.FirstChild;
            }

            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.FirstChild.Name == "block") {
                return false;
            }
            // ラベルはループ文に付くため，ラベルの中身は除外
            var second = e.Siblings().ElementAtOrDefault(1);
            if (second != null && second.TokenText == ":"
                && e.Parent.Name == "statement") {
                return false;
            }
            if (e.FirstChild.TokenText == ";") {
                return false;
            }
            return true;
        }

        /*
blockStatement 
    : localVariableDeclarationStatement
    | classOrInterfaceDeclaration
    | statement
    ;
statement 
    : block
    | ';'
    | IDENTIFIER ':' statement
	| expression ';'
    | ... (snip) ...
	;
		 */

        public IEnumerable<CstNode> SelectStatements(CstNode e) {
            var blockStatements = e.Descendants("blockStatement")
                    .Where(e_ => IsVariableDeclaration(e_) || IsClassDeclaration(e_));
            var statements = e.Descendants("statement")
                    .Where(
                            e_ =>
                                    !IsBlockStatement(e_) && !IsEmptyStatement(e_)
                                    && !IsLabeledStatement(e_));
            return blockStatements.Concat(statements);
        }

        public bool IsVariableDeclaration(CstNode e) {
            // int value = 0;
            return e.FirstChild.Name == "localVariableDeclarationStatement";
        }

        public bool IsClassDeclaration(CstNode e) {
            // class A {}
            return e.FirstChild.Name == "classOrInterfaceDeclaration";
        }

        public bool IsBlockStatement(CstNode e) {
            // { int value = 0; }
            return e.FirstChild.Name == "block";
        }

        public bool IsEmptyStatement(CstNode e) {
            // ;
            return e.TokenText == ";";
        }

        public bool IsLabeledStatement(CstNode e) {
            // LABEL: should_be_ignored();
            var second = e.Siblings().ElementAtOrDefault(1);
            return second != null && second.TokenText == ":";
        }
    }

    public class JavaBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaBlockExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.FirstChild.Name == "block") {
                return true;
            }
            return false;
        }
    }

    public class JavaStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.Name == "statement";
        }
    }

    public class JavaLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaLabeledStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            var second = e.Siblings().ElementAtOrDefault(1);
            if (second != null && second.TokenText == ":"
                && e.Parent.Name == "statement") {
                return true;
            }
            return false;
        }
    }

    public class JavaEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaEmptyStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.TokenText == ";") {
                return true;
            }
            return false;
        }
    }

    public class JavaExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaExpressionStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.FirstChild.Name == "expression";
        }
    }

    public class JavaArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaArithmeticOperatorExperiment() : base("PLUS", "SUB", "STAR", "SLASH") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additiveExpression") ||
                   ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicativeExpression");
        }
    }

    public class JavaSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSwitchCaseExperiment() : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            return e.Name == "switchLabel";
        }
    }

    public class JavaSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperimentWithSwitch() : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (e.Name == "switchLabel") {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return true;
            }
        }
    }

    public class JavaSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return e.TokenText != "true";
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (e.Name == "switchLabel") {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return e.TokenText != "true";
            }
        }
    }
}