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

using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.JavaScript;
using Code2Xml.Objects.Tests.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class JavaScriptCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new JavaScriptCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"")]
        [TestCase(@"var i = 1;")]
        [TestCase(@"function
f() {
	return 1
}")]
        [TestCase(@"for ( var i = 0, j = 0; i < 1; i++, j++ ) { }")]
        [TestCase(@"for(var i = 0, ii = directives.length; i < ii; i++) { }")]
        [TestCase(@"console.log('test')")]
        [TestCase(@"
//
")]
        [TestCase(@"
            compile({
                                          //
                                        });
")]
        [TestCase(@"
return 'a\
b';
")]
        [TestCase(@"
var path = require('path');
var argv = require('optimist').argv;
var completion = require('../lib/completion');
")]
        [TestCase(@"function(name) { this.name = name; }")]
        [TestCase(
                @"if ( first === 0 ) { return diff === 0; } else { return ( diff % first === 0 && diff / first >= 0 ); }"
                )]
        [TestCase("{ a = 0 }")]
        [TestCase(
                "function cv(a){if(!cj[a]){var b=f(\"<\"+a+\">\").appendTo(\"body\"),d=b.css(\"display\");b.remove();if(d===\"none\"||d===\"\"){ck||(ck=c.createElement(\"iframe\"),ck.frameBorder=ck.width=ck.height=0),c.body.appendChild(ck);if(!cl||!ck.createElement)cl=(ck.contentWindow||ck.contentDocument).document,cl.write(\"<!doctype><html><body></body></html>\");b=cl.createElement(a),cl.body.appendChild(b),d=f.css(b,\"display\"),c.body.removeChild(ck)}cj[a]=d}return cj[a]}"
                )]
        [TestCase(@"quickExpr = 'aaaa\naaa\w\Waaa\'a'")]
        [TestCase("quickExpr = \"aaaa\\naaa\\w\\Waaa\\\"a\"")]
        [TestCase(@"quickExpr = /\w\W\/\-/")]
        [TestCase(@"quickExpr = '#'")]
        [TestCase(@"quickExpr = /#/")]
        [TestCase(@"{1}")]
        [TestCase(@"{1}2")]
        [TestCase("\" \\t\\n\\r\\f\\u00A0\"")]
        [TestCase(@"((i = 1))")]
        [TestCase("var a\na = 0")]
        [TestCase("a = \"a\\\nb\"")]
        [TestCase(@"class2type = {};")]
        [TestCase(@"quickExpr = '^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)'")]
        [TestCase("quickExpr = \"^(?:[^<]*(<[\\w]+>)[^>]*$|([\\w]*)$)\"")]
        [TestCase(@"quickExpr = /^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)/")]
        [TestCase(@"rsingleTag = /^<(\w+)\s*\/?>(?:<\/\1>)?$/")]
        [TestCase(@"quickExpr = 'a'")]
        [TestCase("quickExpr = \"a\"")]
        [TestCase(@"quickExpr = /a/")]
        [TestCase(@"{1}{2}")]
        [TestCase(@"[ 1 / 1 ]")]
        [TestCase(@"res.true;")]
        [TestCase(@"res.function;")]
        [TestCase(@"import 'start';")]
        [TestCase(@"module.exports = function(grunt) { };")]
        [TestCase(@"export default xxx;")]
        [TestCase(@"i = 0 + 1 - 2 * 3 / 4;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.js")]
        [TestCase("Block2.js")]
        [TestCase("Block3.js")]
        [TestCase("extracting_branch.js")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("JavaScript", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/jquery/jquery.git",
                @"99d735ab4662f45c3b65ea1200fa0d3e2b671111", 30340)]
        [TestCase(@"https://github.com/joyent/node.git",
                @"940974ed039d3c9a8befe608d9c95b2ffdb457d3", 28954)]
        [TestCase(@"https://github.com/mbostock/d3.git",
                @"49ba8afebb2ae813ab66dc2f48f533aa7f333c3c", 24562)]
        [TestCase(@"https://github.com/angular/angular.js.git",
                @"b10a4371a6592ea1c54b5b9eb401842af7f63c90", 22642)]
        [TestCase(@"https://github.com/bartaz/impress.js.git",
                @"d505df4e4ed20f91b589893cba306fe693ab17d3", 19873)]
        [TestCase(@"https://github.com/jashkenas/backbone.git",
                @"285e07b6b3d6241966866d0662595ac9611c0f61", 17626)]
        [TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
                @"8dc29ded32a0f2caad86ebbdf8b23a22375ae78c", 15847)]
        [TestCase(@"https://github.com/adobe/brackets.git",
                @"23f4531238fcefed98885d5cc1b3c8401b1ac4fd", 15494)]
        [TestCase(@"https://github.com/moment/moment.git",
                @"a05fec84f049fcc4ad81e2c220f430a708458b8a", 15315)]
        [TestCase(@"https://github.com/mrdoob/three.js.git",
                @"4d690145512178c97d4307aecf132b636c5c22ce", 14871)]
        [TestCase(@"https://github.com/hakimel/reveal.js.git",
                @"9da952fea30906090446d038430186b11dba7f13", 14663)]
        [TestCase(@"https://github.com/visionmedia/express.git",
                @"e1ab302234d82390f280ecfb478994cdff8809b6", 13362)]
        [TestCase(@"https://github.com/meteor/meteor.git",
                @"e7a85a39b6803c72a3241f6b6aa455d42eb09f6f", 12130)]
        [TestCase(@"https://github.com/Modernizr/Modernizr.git",
                @"d3043c26388532386b682faf038d3ddba21e27ae", 11846)]
        [TestCase(@"https://github.com/LearnBoost/socket.io.git",
                @"94905500e492d8128e17a355ebf9885bbc4bf93b", 11351)]
        [TestCase(@"https://github.com/jashkenas/underscore.git",
                @"955b57335ab2b458a33465b380c322d2880aa92c", 11037)]
        [TestCase(@"https://github.com/ivaynberg/select2.git",
                @"100266bbb5a16eaefaa45e23de69e1e06464f97a", 10332)]
        [TestCase(@"https://github.com/less/less.js.git",
                @"d6d983f727f6f8342c4d439c784ab90c3c7fea0d", 10283)]
        [TestCase(@"https://github.com/TryGhost/Ghost.git",
                @"0806c3188e202bd15011684332d69848161840f3", 9982)]
        [TestCase(@"https://github.com/resume/resume.github.com.git",
                @"c537d43f3eeb259578f4a0501cb5c0014edd3b72", 9746)]
        [TestCase(@"https://github.com/bower/bower.git",
                @"03f035cdf03ce027892a46d8e0f731dc9b950561", 9334)]
        [TestCase(@"https://github.com/tastejs/todomvc.git",
                @"35fe24713c3ed08ab8bcafcf16a58c4334713ca7", 9037)]
        [TestCase(@"https://github.com/Prinzhorn/skrollr.git",
                @"a08d11500a50d22cfca549864e9a486c17b29c90", 8238)]
        [TestCase(@"https://github.com/mozilla/pdf.js.git",
                @"1b636532d680d269069ca976b02a053392ab5ab2", 8126)]
        [TestCase(@"https://github.com/addyosmani/backbone-fundamentals.git",
                @"7372900a65b6942d234f69f1ed982f094ff5b0bf", 7748)]
        [TestCase(@"https://github.com/nnnick/Chart.js.git",
                @"8f025f33c08c66991a12f02f908bab156a963aef", 7660)]
        [TestCase(@"https://github.com/ajaxorg/ace.git",
                @"993df16bdb4cf80dac13f0fe8f449bb7adb05a65", 7636)]
        [TestCase(@"https://github.com/Leaflet/Leaflet.git",
                @"c5091eefdaa88c5d924c364312f50bf5ab7ba5a5", 7297)]
        [TestCase(@"https://github.com/twitter/typeahead.js.git",
                @"0caa797de2bee9c7f06af08cb5579f8cdfb6a7b9", 7087)]
        [TestCase(@"https://github.com/rwaldron/idiomatic.js.git",
                @"4b2938bd2e2ca3251367572e3613a7a2935aba53", 6831)]
        [TestCase(@"https://github.com/usablica/intro.js.git",
                @"10fab7d91f0ea28e61f32812abb70112ffb3d624", 6827)]
        [TestCase(@"https://github.com/rstacruz/nprogress.git",
                @"4c3af762a7576632a0ca2718a53a17bdeb45efe8", 6789)]
        [TestCase(@"https://github.com/scottjehl/Respond.git",
                @"3fde2627484f8cb38e2bd4dbf2374cf41184b0f4", 6766)]
        [TestCase(@"https://github.com/visionmedia/jade.git",
                @"aa1f1f059b4ca858811c66b6d8b817ff9f41009f", 6340)]
        [TestCase(@"https://github.com/janl/mustache.js.git",
                @"0295646b677b8c9e15527e8b63583ed6728b77d0", 6260)]
        [TestCase(@"https://github.com/ftlabs/fastclick.git",
                @"3497d2e92ccc8a959c7efb326c0fc437302d5bcf", 6250)]
        [TestCase(@"https://github.com/wycats/handlebars.js.git",
                @"085e5e1937b442a4d4add5525db2627e825538aa", 6222)]
        [TestCase(@"https://github.com/wagerfield/parallax.git",
                @"a42beb93b7cdcb9dbfdb0e96e5eafd5232b86ba2", 6060)]
        [TestCase(@"https://github.com/desandro/masonry.git",
                @"b9df286dc6a3004b8a7f90599c7ba79d09e8ce2e", 5871)]
        [TestCase(@"https://github.com/balderdashy/sails.git",
                @"6adfdf85eebdc6e001bacdc5098a58a1cd93aa38", 5852)]
        [TestCase(@"https://github.com/facebook/react.git",
                @"ea361e884e1b6c8458fb64312069e89df0053883", 5638)]
        [TestCase(@"https://github.com/shichuan/javascript-patterns.git",
                @"1a1805763e54c99359d96792e0396b47af649d6c", 5545)]
        [TestCase(@"https://github.com/jrburke/requirejs.git",
                @"f1c533d181da5b759adc7f6297e87d556ef02ce2", 5521)]
        [TestCase(@"https://github.com/gulpjs/gulp.git",
                @"160933474a7d8e566de699dbc6e2f8c4e49c1b5f", 5455)]
        [TestCase(@"https://github.com/flightjs/flight.git",
                @"4b71426ac4776f09ef6c318f4b01c3fbee31b127", 5185)]
        [TestCase(@"https://github.com/carhartl/jquery-cookie.git",
                @"9481ec9eb649e10cd8650d58c0170a36b2da10e7", 5173)]
        [TestCase(@"https://github.com/peachananr/onepage-scroll.git",
                @"fb65fb933553220982fe2c96da2bdc5afb52475b", 5145)]
        [TestCase(@"https://github.com/kriskowal/q.git",
                @"93c00699f22354973e0bccf800d7f03c9413d0d8", 5049)]
        [TestCase(@"https://github.com/kenwheeler/slick.git",
                @"027e8fe6320d2031303acfdbb3b8531d61743093", 4958)]
        [TestCase(@"https://github.com/FredrikNoren/ungit.git",
                @"91c2681cfd9816db2973a06fd5b1c1f81f4f5746", 4947)]
        [TestCase(@"https://github.com/jquery-ui-bootstrap/jquery-ui-bootstrap.git",
                @"439e6662414f4dc7feb2032186d1f2a784f6455d", 4886)]
        [TestCase(@"https://github.com/knockout/knockout.git",
                @"80120969d8cb5341325f76ec1e74dde6e2af00fc", 4846)]
        [TestCase(@"https://github.com/rstacruz/jquery.transit.git",
                @"857c438ed80120f20052edd78872175bff4343dc", 4834)]
        [TestCase(@"https://github.com/marionettejs/backbone.marionette.git",
                @"84e735d7d7cf85957fe08caebcd086cf7ee11e42", 4743)]
        [TestCase(@"https://github.com/lodash/lodash.git",
                @"7384c42d7a7e63804fd8503cecbc26c13c25eb2a", 4723)]
        [TestCase(@"https://github.com/LearnBoost/mongoose.git",
                @"f243bc9453a3c43cd00f89d0df0f7feb097f3668", 4704)]
        [TestCase(@"https://github.com/scottjehl/picturefill.git",
                @"bc7b1250a2d7795210f9f1f4650de61ceb117d0f", 4687)]
        [TestCase(@"https://github.com/ajaxorg/cloud9.git",
                @"5b62a7c83445ccba9f50592d41a7128b1f1fe868", 4681)]
        [TestCase(@"https://github.com/angular/angular-seed.git",
                @"d38e34855b4bda3efaeed63a81844ef94331e3b2", 4668)]
        [TestCase(@"https://github.com/driftyco/ionic.git",
                @"14a2790749f2d65ec6f0c652d5aac7a4a9d72c24", 4663)]
        [TestCase(@"https://github.com/angular-ui/bootstrap.git",
                @"2423f6d4c05cb0eb3fd2104dedbeb0e3740f7f68", 4610)]
        [TestCase(@"https://github.com/Kicksend/mailcheck.git",
                @"5ff8678cc4b7ec36c4442ccc6213910aa734f4d7", 4536)]
        [TestCase(@"https://github.com/javve/list.js.git",
                @"9754c28262b07e647e0ad3de181cdb4e323e7db7", 4533)]
        [TestCase(@"https://github.com/mikeal/request.git",
                @"6a4fd9ad6f57ba27a24f7cea01d0c702f7f5fefa", 4507)]
        [TestCase(@"https://github.com/HPNeo/gmaps.git",
                @"edbb7362d6fd050a38bded00a7396a760d3f556a", 4494)]
        [TestCase(@"https://github.com/hakimel/Ladda.git",
                @"5ec83261fbd2fd2613ec8efe83c90996ac289e7c", 4479)]
        [TestCase(@"https://github.com/marijnh/CodeMirror.git",
                @"8a6778baf496da5c80fe785304fdd0e3d5ec8adb", 4461)]
        [TestCase(@"https://github.com/desandro/isotope.git",
                @"829eaeadc6434e4d313b627ccff4e74c759a1051", 4437)]
        [TestCase(@"https://github.com/gollum/gollum.git",
                @"ff82ddea9740b1ca7206c17af4f55a6250ba3cfd", 4386)]
        [TestCase(@"https://github.com/visionmedia/mocha.git",
                @"638e049cfae48f35493c8b4bf3c5debe5691d751", 4346)]
        [TestCase(@"https://github.com/senchalabs/connect.git",
                @"bed911ebb94c7c682fe6a72ae6414eed69301c34", 4286)]
        [TestCase(@"https://github.com/jakiestfu/Snap.js.git",
                @"8538051df8e2c82a39d2603b6dfd8219ce8f04e6", 4284)]
        [TestCase(@"https://github.com/eternicode/bootstrap-datepicker.git",
                @"8bc254a136110369684dc05a48171682ff1f3a81", 4274)]
        [TestCase(@"https://github.com/marmelab/gremlins.js.git",
                @"06d1d0f9abffdad9d72f31d2d3337e7d1a567de2", 4273)]
        [TestCase(@"https://github.com/node-inspector/node-inspector.git",
                @"a7c4fa23a46af15cf265ec4662f6340ccb40f337", 4260)]
        [TestCase(@"https://github.com/substack/node-browserify.git",
                @"2bfdd64ef45e5c1760fe8fa90e2c80033a238d12", 4246)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new JavaScriptComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "js_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.js");
        }

        [Test]
        public void ParseComment() {
            var e = Generator.GenerateTreeFromCodeText(
                    @"function(name) { /*a*/ } //aa
/*
c*/");
            Assert.That(
                    e.AllHiddens()
                            .Count(e2 => e2.Name == "Comment" || e2.Name == "LineComment"),
                    Is.EqualTo(3));
            var pos = e.AllHiddens("Comment").Last().Range;
            Assert.That(pos.StartLine, Is.EqualTo(2));
            Assert.That(pos.EndLine, Is.EqualTo(3));
            Assert.That(pos.StartPosition, Is.EqualTo(0));
            Assert.That(pos.EndPosition, Is.EqualTo(3));
        }
    }
}