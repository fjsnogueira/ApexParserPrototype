using ApexParser.MetaClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Parser;
using NUnit.Framework;
using Sprache;

namespace ApexParserTest.Parser
{
    [TestFixture]
    public class MethodTestData
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Test, Ignore("TODO")]
        public void MethodSigTestOne()
        {
            var methodSig = "public static void GetNumber(string name) { /* Comment */ }";

            MethodSyntax methodSyntax = new MethodSyntax();
            methodSyntax.Modifiers.Add("public");
            methodSyntax.Modifiers.Add("static");
            methodSyntax.ReturnType = "void";
            methodSyntax.Identifier = "GetNumber";
            methodSyntax.MethodParameters.Add(new ParameterSyntax("string", "name"));
            methodSyntax.CodeInsideMethod = "{ /* Comment */ }";

            var method = Apex.MethodDeclaration.Parse(methodSig);

            Assert.AreEqual("void", method.ReturnType);
        }
    }
}
