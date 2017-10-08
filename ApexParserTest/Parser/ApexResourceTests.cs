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

        // I'll put the original location of the file in the description, for future reference
        // In case the original file is modified, it should be add as a new resource
        // Old resource files should not be modified so we don't need to fix the old tests
        [Test(Description = @"\ApexParser\SalesForceApexSharp\src\classes\ClassOne.cls")]
        public void ClassOneTest()
        {
            var cd = Apex.ClassDeclaration.Parse(Resources.ClassOne);
            Assert.AreEqual("ClassOne", cd.Identifier);
            Assert.AreEqual(1, cd.Methods.Count);

            var md = cd.Methods[0];
            Assert.AreEqual("CallClassTwo", md.Identifier);
            Assert.False(md.CodeComments.Any());
            Assert.False(md.Attributes.Any());
            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("void", md.ReturnType.Identifier);
            Assert.AreEqual(@"ClassTwo classTwo = new ClassTwo();
        System.debug('Test');", md.CodeInsideMethod);
        }

        [Test(Description = @"\ApexParser\SalesForceApexSharp\src\classes\ClassTwo.cls"), Ignore("TODO: add constructors to the grammar")]
        public void ClassTwoTest()
        {
            var cd = Apex.ClassDeclaration.Parse(Resources.ClassTwo);
            Assert.AreEqual("ClassTwo", cd.Identifier);
            Assert.AreEqual(2, cd.Methods.Count);

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
        }

        [Test(Description = @"\ApexParser\SalesForceApexSharp\src\classes\Demo.cls"), Ignore("TODO: match open/closed braces")]
        public void DemoTest()
        {
            var cd = Apex.ClassDeclaration.Parse(Resources.Demo);
            Assert.AreEqual("Demo", cd.Identifier);
            Assert.AreEqual(1, cd.Methods.Count);
        }
    }
}
