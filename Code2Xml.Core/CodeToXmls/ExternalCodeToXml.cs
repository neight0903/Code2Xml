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

using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClass(typeof(ExternalCodeToXmlContract))]
	public abstract class ExternalCodeToXml : CodeToXml {
		protected static readonly Encoding Encoding = new UTF8Encoding(false);

		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				return "";
			}
		}

		public override XElement Generate(TextReader reader, bool throwingParseError) {
			var info = new ProcessStartInfo {
					FileName = ProcessorPath,
					Arguments = Arguments.JoinString(" "),
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					StandardOutputEncoding = Encoding,
					RedirectStandardError = true,
					UseShellExecute = false,
					WorkingDirectory = WorkingDirectory,
			};
			Debug.WriteLine(ProcessorPath);
			Debug.WriteLine(Arguments.JoinString(" "));
			Debug.WriteLine(Environment.CurrentDirectory);
			using (var p = Process.Start(info)) {
				using (var write = new StreamWriter(p.StandardInput.BaseStream, Encoding)) {
					write.WriteFromStream(reader);
				}
				var xmlStr = p.StandardOutput.ReadToEnd();
				var normalizedXmlStr = Normalize(xmlStr);
				Debug.WriteLine(p.StandardError.ReadToEnd());
				return XDocument.Parse(normalizedXmlStr).Root;
			}
		}

		protected virtual string Normalize(string xml) {
			//TODO: 応急処置をやめる
			var buf = new StringBuilder(xml.Length);
			for (int i = 0; i < xml.Length; i++) {
				var c = xml[i];
				if (char.IsControl(c) && c != '\r' && c != '\n') {
					c = ' ';
				}
				buf.Append(c);
			}
			return buf.ToString();
		}
	}
}