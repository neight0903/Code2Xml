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

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClass(typeof(AntlrCodeToXmlContract<>))]
	public abstract class AntlrCodeToXml<TParser> : CodeToXml
			where TParser : Parser, IAntlrParser {
		protected bool CanThrowParseError { get; set; }

		protected abstract Func<TParser, XAstParserRuleReturnScope>
			DefaultParseFunc { get; }

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		private XElement Generate(
				ICharStream stream,
				Func<TParser, XAstParserRuleReturnScope> parseFunc,
				bool throwingParseError,
				bool enablePosition = true
				) {
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);
			parser.TraceDestination = Console.Error;
			if (throwingParseError) {
				parser.TreeAdaptor = new ThrowableXmlTreeAdaptor();
			}
			parser.TreeAdaptor.TokenStream = tokens;
			parser.TreeAdaptor.EnablePosition = enablePosition;

			// Launch parsing
			var element = parseFunc(parser).Element;

			for (int i = 0; i < tokens.Count; i++) {
				var t = tokens.Get(i);
				if (t.Channel == TokenChannels.Hidden) {
					var comment = new XElement(Code2XmlConstants.CommentName);
					comment.Value = t.Text;
					comment.SetAttributeValue(Code2XmlConstants.StartLineName, t.Line);
					comment.SetAttributeValue(
							Code2XmlConstants.StartPositionName, t.CharPositionInLine);
					//var t2 = tokens.Get(i + 1);
					//comment.SetAttributeValue(Code2XmlConstants.EndLineName, t2.Line);
					//comment.SetAttributeValue(
					//        Code2XmlConstants.EndPositionName, t2.CharPositionInLine);
					element.Add(comment);
				}
			}

			return element;
		}

		private XElement Generate(
				ICharStream stream, string nodeName, bool throwingParseError) {
			return Generate(
					stream,
					p =>
					(XAstParserRuleReturnScope)
					p.GetType().GetMethod(nodeName).Invoke(p, null),
					throwingParseError);
		}

		public XElement Generate(
				string code, string nodeName, bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(
					new ANTLRStringStream(code), nodeName, throwingParseError);
		}

		public XElement Generate(string code, string nodeName) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(code, nodeName, DefaultThrowingParseError);
		}

		public XElement Generate(
				string code,
				Func<TParser, XAstParserRuleReturnScope> parseAction,
				bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(
					new ANTLRStringStream(code), parseAction, throwingParseError);
		}

		public XElement Generate(
				string code,
				Func<TParser, XAstParserRuleReturnScope> parseAction) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(
					new ANTLRStringStream(code), parseAction,
					DefaultThrowingParseError);
		}

		private XElement GenerateWithoutPosition(
				ICharStream stream, string nodeName, bool throwingParseError) {
			return Generate(
					stream,
					p =>
					(XAstParserRuleReturnScope)
					p.GetType().GetMethod(nodeName).Invoke(p, null),
					throwingParseError,
					false);
		}

		public XElement GenerateWithoutPosition(
				string code, string nodeName, bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return GenerateWithoutPosition(
					new ANTLRStringStream(code), nodeName, throwingParseError);
		}

		public XElement GenerateWithoutPosition(string code, string nodeName) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return GenerateWithoutPosition(code, nodeName, DefaultThrowingParseError);
		}

		public XElement GenerateWithoutPosition(
				string code,
				Func<TParser, XAstParserRuleReturnScope> parseAction,
				bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(
					new ANTLRStringStream(code), parseAction, throwingParseError, false);
		}

		public XElement GenerateWithoutPosition(
				string code,
				Func<TParser, XAstParserRuleReturnScope> parseAction) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(
					new ANTLRStringStream(code), parseAction,
					DefaultThrowingParseError, false);
		}

		public override XElement Generate(
				TextReader reader, bool throwingParseError) {
			return Generate(
					new ANTLRReaderStream(reader), DefaultParseFunc,
					throwingParseError);
		}

		public override XElement Generate(string code, bool throwingParseError) {
			return Generate(
					new ANTLRStringStream(code), DefaultParseFunc,
					throwingParseError);
		}
			}
}