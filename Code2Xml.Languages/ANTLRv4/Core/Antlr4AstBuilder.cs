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

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Code2Xml.Core;
using Code2Xml.Core.Location;

namespace Code2Xml.Languages.ANTLRv4.Core {
	public class Antlr4AstBuilder : AbstractParseTreeVisitor<object> {
		private readonly string[] _parserRuleNames;
		private readonly XElement _dummyRoot;
		private readonly Stack<XElement> _elements;
		private readonly CommonTokenStream _stream;
		private readonly XElement _dummyNode;
		private XElement _lastElement;
		private int _lastTokenIndex;
		private int _lastDepth;

		public Antlr4AstBuilder(Parser parser) {
			_parserRuleNames = parser.RuleNames;
			_stream = (CommonTokenStream)parser.InputStream;
			_dummyRoot = new XElement("root");
			_dummyNode = new XElement("dummy");
			_elements = new Stack<XElement>(new[] { _dummyRoot });
			_lastElement = _dummyNode;
			_lastTokenIndex = -1;
		}

		public XElement FinishParsing() {
			var size = _stream.Size - 1; // Avoid writing "<EOF>"
			for (int i = _lastTokenIndex + 1; i < size; i++) {
				var oldToken = _stream.Get(i);
				var name = oldToken.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
				_lastElement.Add(CreateTokenElement(name, oldToken));
			}

			var root = _dummyRoot.Elements().First();
			var firstTokensNode = root.Descendants("TOKENS").FirstOrDefault() ??
			                      root.Descendants().LastOrDefault();
			if (firstTokensNode != null) {
				foreach (var element in _dummyNode.Elements().Reverse()) {
					firstTokensNode.AddFirst(element);
				}
			}
			return root;
		}

		public override object VisitTerminal(ITerminalNode node) {
			var token = node.Symbol;
			if (token.Type > 0) {
				var tokenIndex = token.TokenIndex;
				for (int i = _lastTokenIndex + 1; i < tokenIndex; i++) {
					var oldToken = _stream.Get(i);
					var name = oldToken.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
					_lastElement.Add(CreateTokenElement(name, oldToken));
				}
				_lastTokenIndex = tokenIndex;
				_lastElement = new XElement("TOKENS", CreateTokenElement("TOKEN", token));
				_elements.Peek().Add(_lastElement);
			}
			return base.VisitTerminal(node);
		}

		public override object VisitChildren(IRuleNode node) {
			var name = _parserRuleNames[node.RuleContext.GetRuleIndex()];
			var maxDepth = _lastDepth + 1;
			for (int i = node.RuleContext.Depth(); i < maxDepth; i++) {
				_elements.Pop();
			}
			var element = new XElement(name);
			_elements.Peek().Add(element);
			_lastDepth = node.RuleContext.Depth();
			_elements.Push(element);
			return base.VisitChildren(node);
		}

		private static XElement CreateTokenElement(string name, IToken token) {
			var tokenElement = new XElement(name, token.Text);
			var startLocation = new CodeLocation(token.Line, token.Column);
			return CodeRange.SetLocationAttributes(tokenElement, startLocation);
		}
	}
}