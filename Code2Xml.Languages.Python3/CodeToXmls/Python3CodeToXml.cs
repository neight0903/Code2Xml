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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using Code2Xml.Core;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Python3.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class Python3CodeToXml : ExternalCodeToXml {
        private static Python3CodeToXml _instance;

        private static readonly string[] PrivateArguments = new[] {
                "ParserScripts/Python3/st2xml.py",
        };

        private readonly string _processorPath;

        public Python3CodeToXml()
                : this(Settings.GetPythonInstallPath("3.") ?? "python") {}

        public Python3CodeToXml(string processorPath) {
            _processorPath = processorPath;
        }

        public static Python3CodeToXml Instance {
            get { return _instance ?? (_instance = new Python3CodeToXml()); }
        }

        protected override string ProcessorPath {
            get { return _processorPath; }
        }

        protected override string[] Arguments {
            get { return PrivateArguments; }
        }

        public override string ParserName {
            get { return "Python3"; }
        }

        public override IEnumerable<string> TargetExtensions {
            get { return new[] { ".py" }; }
        }
    }
}