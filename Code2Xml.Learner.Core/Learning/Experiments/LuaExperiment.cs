#region License

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
    public class LuaExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.LuaUsingAntlr3;

        private const string LangName = "Lua";

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/kennyledet/Algorithm-Implementations.git",
                    @"ec423a1984fa923e117053c114c92ae86d32bfd4"),
            Tuple.Create(
                    @"https://github.com/nrk/redis-lua.git",
                    @"4408c3d686ffd1f2689c0561a166821785cc09ec"),
            Tuple.Create(
                    @"https://github.com/gamesys/moonshine.git",
                    @"ca6d7a57bfb676caf409e7398a448f90eb139b47"),
            Tuple.Create(
                    @"https://github.com/tekkub/wow-ui-source.git",
                    @"e9e777a6d1baca29d6253260a69463767d8d9b00"),
            Tuple.Create(
                    @"https://github.com/minetest/minetest_game.git",
                    @"15740ffd3d1ea1af182a8607c600f3af414c2c73"),
            Tuple.Create(
                    @"https://github.com/kikito/lua_missions.git",
                    @"330d7702417c4b18358ab822ba676058892ad889"),
            Tuple.Create(
                    @"https://github.com/kernelsauce/turbo.git",
                    @"d1411bbbcbe18cb20a7d91bb95505d952993c31f"),
            Tuple.Create(
                    @"https://github.com/appwilldev/moochine.git",
                    @"9f643a5b51fb132c11ec1c870e4979cf03012992"),
            Tuple.Create(
                    @"https://github.com/Fluorohydride/ygopro.git",
                    @"16a98132749215b8ca27f6e479976ef42c4cd0fc"),
            Tuple.Create(
                    @"https://github.com/Shestak/ShestakUI.git",
                    @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852"),
            Tuple.Create(
                    @"https://github.com/pavouk/lgi.git",
                    @"3feb90f4c0c20312e646fb8b1106a5c44a04293e"),
            Tuple.Create(
                    @"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                    @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f"),
            Tuple.Create(
                    @"https://github.com/pkulchenko/MobDebug.git",
                    @"c2b9988ccda7998be466da67690316b45fd3469a"),
            Tuple.Create(
                    @"https://github.com/davidm/lua-inspect.git",
                    @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3"),
            Tuple.Create(
                    @"https://github.com/lipp/lua-websockets.git",
                    @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be"),
            Tuple.Create(
                    @"https://github.com/harningt/luajson.git",
                    @"827425b10152f8cdc515e4ffb900338506e28910"),
            Tuple.Create(
                    @"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                    @"471868fe6cad288cac57281b5218cdd711b826eb"),
            Tuple.Create(
                    @"https://github.com/miko/Love2d-samples.git",
                    @"50a8b4b43d517081a83d036e4510904402dcd7d2"),
            Tuple.Create(
                    @"https://github.com/Neopallium/lua-handlers.git",
                    @"ae93f442175f4f03dd612cafa073df74a8fe626f"),
            Tuple.Create(
                    @"https://github.com/cedlemo/blingbling.git",
                    @"7ac39503e2811042cf0d83a0874d230779a710ef"),
            Tuple.Create(
                    @"https://github.com/radamanthus/corona-game-template.git",
                    @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2"),
            Tuple.Create(
                    @"https://github.com/ostinelli/gin.git",
                    @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76"),
            Tuple.Create(
                    @"https://github.com/ymobe/rapanui.git",
                    @"595076d5706695a8b9b8de393b749d7d90a414a2"),
            Tuple.Create(
                    @"https://github.com/bjc/prosody.git",
                    @"701fa72ca55909888b3fd428724128c654d8b543"),
            Tuple.Create(
                    @"https://github.com/Yonaba/Jumper.git",
                    @"2479afadf3d50e30ea9f9ab104e6229176d57339"),
            Tuple.Create(
                    @"https://github.com/iamgreaser/iceball.git",
                    @"4ae5d09ce4fd2269f4e097b63bd0fd9b83f2198f"),
            Tuple.Create(
                    @"https://github.com/xopxe/Lumen.git",
                    @"264d9d042ee9848bccfd064d69259c1d6bde0a2e"),
            Tuple.Create(
                    @"https://github.com/Bertram25/ValyriaTear.git",
                    @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e"),
            Tuple.Create(
                    @"https://github.com/Yonaba/Moses.git",
                    @"57c7b5d1d1f074cafbd570088ad8681b03c65601"),
            Tuple.Create(
                    @"https://github.com/metadeus/luv.git",
                    @"655c0efc14572d18744aff336210b30574dd7eaf"),
            Tuple.Create(
                    @"https://github.com/lubyk/dub.git",
                    @"b0c7087e878937399f329468bff41de9484f8b0c"),
            Tuple.Create(
                    @"https://github.com/pygy/LuLPeg.git",
                    @"c457b27e0d7fc935b133921bf3aee92efffe40c8"),
            Tuple.Create(
                    @"https://github.com/lua-nucleo/lua-nucleo.git",
                    @"570e115dab1260ad433bd778eebb5d91fd122d5a"),
            Tuple.Create(
                    @"https://github.com/annulen/premake.git",
                    @"c559fa4913bd86be6e415c3b193db90ae4607f5b"),
            Tuple.Create(
                    @"https://github.com/Neopallium/LuaNativeObjects.git",
                    @"a5c444769b7dfad1436a1bc4fe21dce75629db25"),
            Tuple.Create(
                    @"https://github.com/SiENcE/lovecodify.git",
                    @"9b84ce1a5f3474707e6021355afd6c2554f18251"),
            Tuple.Create(
                    @"https://github.com/jp-ganis/JPS.git",
                    @"c65f107fa59a5f572e0ffd70be7990a873d87487"),
            Tuple.Create(
                    @"https://github.com/stravant/LuaMinify.git",
                    @"c284a942089b0154af7498b110e02d1bba8aee16"),
            Tuple.Create(
                    @"https://github.com/UPenn-RoboCup/UPennalizers.git",
                    @"abd9b34294a6485965be274333b72f1272f8f3c8"),
            Tuple.Create(
                    @"https://github.com/SimonLarsen/mrrescue.git",
                    @"8f226413b95544d0e0744d9c3e92c68b87659483"),
            Tuple.Create(
                    @"https://github.com/meric/l2l.git",
                    @"e9394879e9bde63b1b21e39928ac19f304fc1b39"),
            Tuple.Create(
                    @"https://github.com/dmccuskey/DMC-Corona-Library.git",
                    @"8c85803e39a673cc84b6aa089b51be56f05dd062"),
            Tuple.Create(
                    @"https://github.com/Neopallium/lua-pb.git",
                    @"862fe3121e71f695d9a44ee1d1038069292b69f3"),
            Tuple.Create(
                    @"https://github.com/SnakeSVx/spacebuild.git",
                    @"68186b8bc7cabbb5275afd734fae9613fbd8761d"),
            Tuple.Create(
                    @"https://github.com/Wiladams/LAPHLibs.git",
                    @"aed3531fb6face76c5634bde995e9cf503d6136b"),
            Tuple.Create(
                    @"https://github.com/tales/sourceoftales.git",
                    @"f259c99ebb42a4956f6e4c5464051651a3226d5a"),
            Tuple.Create(
                    @"https://github.com/paulofmandown/rotLove.git",
                    @"bb089f3294ba9cd1f7cc031dffc0b695fa2ed4bf"),
            Tuple.Create(
                    @"https://github.com/Eonblast/fleece-lite.git",
                    @"06103ea87601c74801ca5780bc9014011243bbec"),
            Tuple.Create(
                    @"https://github.com/ildyria/iFilger.git",
                    @"d092e040143146a551b6821b6a9b199a4b98e9db"),
        };

        private static readonly LearningExperiment[] Experiments = {
            new LuaComplexStatementExperiment(),
            new LuaSuperComplexBranchExperiment(),
            new LuaExpressionStatementExperiment(),
            new LuaArithmeticOperatorExperiment(),
            //new LuaSuperComplexBranchExperimentWithoutTrue(), 

            //new LuaComplexBranchExperiment(),
            //new LuaStatementExperiment(),
            //new LuaIfExperiment(),
            //new LuaWhileExperiment(),
            //new LuaDoWhileExperiment(),
            //new LuaPrintExperiment(),
            //new LuaStatementExperiment(),
            //new LuaLabeledStatementExperiment(),
            //new LuaEmptyStatementExperiment(),
        };

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

        protected override string SearchPattern {
            get { return "*.lua"; }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.lua"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.lua"), };
            Learn(seedPaths, exp, projectPath);
        }
    }

    public class LuaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaComplexBranchExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            return false;
        }
    }

    public class LuaSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public override int MaxUp {
            get { return 4; }
        }

        public override int MaxLeft {
            get { return 1; }
        }

        public override int MaxRight {
            get { return 0; }
        }

        public LuaSuperComplexBranchExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            var ppp = e.SafeParent().SafeParent().SafeParent();
            var pppp = ppp.SafeParent();
            if (pppp.SafeName() == "functioncall" && ppp.Prev != null
                && ppp.Prev.TokenText == "print") {
                return true;
            }
            return false;
        }

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return new[] { e.Prev, e, e.Next };
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return new[] { e.Prev, e, e.Next };
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return new[] { e.Prev, e };
            }
            var ppp = e.SafeParent().SafeParent().SafeParent();
            var pppp = ppp.SafeParent();
            if (pppp.SafeName() == "functioncall" && ppp.Prev != null
                && ppp.Prev.TokenText == "print") {
                return new[] { pppp };
            }
            return new CstNode[0];
        }
    }

    public class LuaSuperComplexBranchExperimentWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public override int MaxUp {
            get { return 4; }
        }

        public override int MaxLeft {
            get { return 1; }
        }

        public override int MaxRight {
            get { return 0; }
        }

        public LuaSuperComplexBranchExperimentWithoutTrue() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return e.TokenText != "true";
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return e.TokenText != "true";
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return e.TokenText != "true";
            }
            var ppp = e.SafeParent().SafeParent().SafeParent();
            var pppp = ppp.SafeParent();
            if (pppp.SafeName() == "functioncall" && ppp.Prev != null
                && ppp.Prev.TokenText == "print") {
                return e.TokenText != "true";
            }
            return false;
        }

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return new[] { e.Prev, e, e.Next };
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return new[] { e.Prev, e, e.Next };
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return new[] { e.Prev, e };
            }
            var ppp = e.SafeParent().SafeParent().SafeParent();
            var pppp = ppp.SafeParent();
            if (pppp.SafeName() == "functioncall" && ppp.Prev != null
                && ppp.Prev.TokenText == "print") {
                return new[] { pppp };
            }
            return new CstNode[0];
        }
    }

    public class LuaIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaIfExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            return false;
        }
    }

    public class LuaWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaWhileExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            return false;
        }
    }

    public class LuaDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaDoWhileExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            return false;
        }
    }

    public class LuaPrintExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaPrintExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var ppp = e.SafeParent().SafeParent().SafeParent();
            var pppp = ppp.SafeParent();
            if (pppp.SafeName() == "functioncall" && ppp.Prev != null
                && ppp.Prev.TokenText == "print") {
                return true;
            }
            return false;
        }
    }

    public class LuaComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaComplexStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "label") {
                return false;
            }
            if (e.FirstChild.TokenText == ";") {
                return false;
            }
            return true;
        }
    }

    public class LuaStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }
    }

    public class LuaLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaLabeledStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "label") {
                return true;
            }
            return false;
        }
    }

    public class LuaEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaEmptyStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.TokenText == ";") {
                return true;
            }
            return false;
        }
    }

    public class LuaExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaExpressionStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.FirstChild.Name == "varlist";
        }
    }

    public class LuaArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public override int MaxUp {
            get { return 1; }
        }

        public override int MaxLeft {
            get { return 0; }
        }

        public override int MaxRight {
            get { return 0; }
        }

        public LuaArithmeticOperatorExperiment() : base("TOKENS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "binop") {
                e = e.FirstChild;
            }
            return e.Parent.Name == "binop"
                   && (e.TokenText == "+" || e.TokenText == "-" || e.TokenText == "*"
                       || e.TokenText == "/");
        }

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            if (e.Name == "binop") {
                e = e.FirstChild;
            }
            if (e.Parent.Name == "binop"
                && (e.TokenText == "+" || e.TokenText == "-" || e.TokenText == "*"
                    || e.TokenText == "/")) {
                return new[] { e.Parent };
            }
            return new CstNode[0];
        }
    }
}