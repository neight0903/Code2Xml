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
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;
using Antlr4.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Processors.Lua {
	/// <summary>
	/// Represents a Lua parser and a Lua code generator.
	/// </summary>
	[Export(typeof(LanguageProcessor))]
	public class LuaProcessor : Antlr4Processor<LuaParser, LuaProcessor> {
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
			get { return "5.2"; }
		}

		public LuaProcessor() : base(".lua") {}

		protected override ITokenSource CreateLexer(ICharStream stream) {
			return new LuaLexer(stream);
		}

		protected override LuaParser CreateParser(CommonTokenStream stream) {
			return new LuaParser(stream);
		}

		protected override ParserRuleContext Parse(LuaParser parser) {
			return parser.chunk();
		}
	}
}