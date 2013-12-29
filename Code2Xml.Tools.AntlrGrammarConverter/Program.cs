﻿using System;
using System.Text.RegularExpressions;

namespace Code2Xml.Tools.AntlrGrammarConverter {
	internal class Program {
		private static void Main(string[] args) {
			var succeeded = false;
			var lastChar = 'a';
			Console.Write("[");
			for (int i = 0; i < 65536; i++) {
				var c = (char)i;
				var match = Regex.Match("" + c, @"[\p{Cf}]");
				if (match.Success) {
					if (!succeeded) {
						Console.Write(GetEscapeSequence(c));
						succeeded = true;
						lastChar = c;
					}
				} else {
					if (succeeded) {
						if (lastChar != c - 1) {
							Console.Write("-" + GetEscapeSequence((char)(c - 1)));
						}
						succeeded = false;
					}
				}
			}
			if (succeeded) {
				Console.Write(" - " + GetEscapeSequence((char)(65535)));
			}
			Console.WriteLine("]");
			//var input = File.ReadAllText(@"C:\Users\exKAZUu\Desktop\csharp.g4");
			//var output = new CSharp().Generate(input);
			//File.WriteAllText(@"C:\Users\exKAZUu\Desktop\csharp2.g4", output);
		}

		private static string GetEscapeSequence(char c) {
			return "\\u" + ((int)c).ToString("X4");
		}
	}
}