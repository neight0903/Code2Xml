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

using System.ComponentModel.Composition;
using Antlr.Runtime;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv3.Lua {
    /// <summary>
    /// Represents a Lua parser and a Lua code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class LuaCstGeneratorUsingAntlr3 : CstGeneratorUsingAntlr3<LuaParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Lua"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "5.1"; }
        }

        public LuaCstGeneratorUsingAntlr3() : base(".lua") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new LuaLexer(stream);
        }

        protected override LuaParser CreateParser(ITokenStream stream) {
            return new LuaParser(stream);
        }

        protected override CstNode Parse(LuaParser parser) {
            return parser.chunk();
        }
    }
}