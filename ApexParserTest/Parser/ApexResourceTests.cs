using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Parser;
using ApexParserTest.Properties;
using NUnit.Framework;
using Sprache;

namespace ApexParserTest.Parser
{
    [TestFixture]
    public class ApexResourceTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Test]
        public void MethodsOneTest()
        {

            string myDevdir = @"C:\DevSharp";
            string apexCode = File.ReadAllText(myDevdir + @"\ApexParser\SalesForceApexSharp\src\classes\Demo.cls");



            var cd = Apex.ClassDeclaration.Parse(apexCode); // can we use the real file
            Assert.AreEqual("MethodOne", cd.Identifier);
            Assert.AreEqual(8, cd.Methods.Count);

            var md = cd.Methods[0];
            Assert.AreEqual("StringVoid", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.False(md.Modifiers.Any());
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual(string.Empty, md.CodeInsideMethod);

            md = cd.Methods[1];
            Assert.AreEqual("StringPublic", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual(string.Empty, md.CodeInsideMethod);

            md = cd.Methods[2];
            Assert.AreEqual("GetString", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.False(md.Modifiers.Any());
            Assert.AreEqual("string", md.ReturnType.Identifier);
            Assert.AreEqual("return 'Hello World';", md.CodeInsideMethod);

            md = cd.Methods[3];
            Assert.AreEqual("GetStringPublic", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("string", md.ReturnType.Identifier);
            Assert.AreEqual("return 'Hello World';", md.CodeInsideMethod);

            md = cd.Methods[4];
            Assert.AreEqual("GetStringprivate", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("private", md.Modifiers[0]);
            Assert.AreEqual("string", md.ReturnType.Identifier);
            Assert.AreEqual("return 'Hello World';", md.CodeInsideMethod);

            md = cd.Methods[5];
            Assert.AreEqual("GetStringglobal", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("global", md.Modifiers[0]);
            Assert.AreEqual("string", md.ReturnType.Identifier);
            Assert.AreEqual("return 'Hello World';", md.CodeInsideMethod);

            md = cd.Methods[6];
            Assert.AreEqual("GetGenericList", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.False(md.Modifiers.Any());
            Assert.AreEqual("List", md.ReturnType.Identifier);
            Assert.False(md.ReturnType.Namespaces.Any());
            Assert.AreEqual(1, md.ReturnType.TypeParameters.Count);
            Assert.AreEqual("string", md.ReturnType.TypeParameters[0].Identifier);
            Assert.AreEqual("return new List<string>();", md.CodeInsideMethod);

            md = cd.Methods[7];
            Assert.AreEqual("GetGenericMap", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.False(md.Modifiers.Any());
            Assert.AreEqual("Map", md.ReturnType.Identifier);
            Assert.False(md.ReturnType.Namespaces.Any());
            Assert.AreEqual(2, md.ReturnType.TypeParameters.Count);
            Assert.AreEqual("string", md.ReturnType.TypeParameters[0].Identifier);
            Assert.AreEqual("string", md.ReturnType.TypeParameters[1].Identifier);
            Assert.AreEqual("return new Map<string, string>();", md.CodeInsideMethod);
        }

        [Test]
        public void MethodsTwoTest()
        {

            string myDevdir = @"C:\DevSharp";
            string apexCode = File.ReadAllText(myDevdir + @"\ApexParser\SalesForceApexSharp\src\classes\Demo.cls");


            var cd = Apex.ClassDeclaration.Parse(apexCode); // can we use the real file
            Assert.AreEqual("MethodTwo", cd.Identifier);
            Assert.AreEqual(4, cd.Methods.Count);

            var md = cd.Methods[0];
            Assert.AreEqual("TestMethodOne", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.AreEqual(1, md.Attributes.Count);
            Assert.AreEqual("isTest", md.Attributes[0]);
            Assert.AreEqual(2, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("static", md.Modifiers[1]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual("System.debug('TestMethodOne');", md.CodeInsideMethod);

            md = cd.Methods[1];
            Assert.AreEqual("TestMethodThree", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.AreEqual(1, md.Attributes.Count);
            Assert.AreEqual("isTest", md.Attributes[0]);
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("static", md.Modifiers[0]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual("System.debug('TestMethodThree');", md.CodeInsideMethod);

            md = cd.Methods[2];
            Assert.AreEqual("TestMethodFour", md.Identifier);
            Assert.AreEqual(1, md.CodeComments.Count);
            Assert.AreEqual(" Does Not Work", md.CodeComments[0]);
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(2, md.Modifiers.Count);
            Assert.AreEqual("static", md.Modifiers[0]);
            Assert.AreEqual("testMethod", md.Modifiers[1]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual("System.debug('TestMethodFour');", md.CodeInsideMethod);

            md = cd.Methods[3];
            Assert.AreEqual("TestMethodTwo", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(3, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("testMethod", md.Modifiers[1]);
            Assert.AreEqual("static", md.Modifiers[2]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual("System.debug('TestMethodTwo');", md.CodeInsideMethod);
        }

    }
}
