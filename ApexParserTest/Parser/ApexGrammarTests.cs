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
    public class ApexGrammarTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Test]
        public void IdentifierIsALetterFollowedByALetterOrDigit()
        {
            // every test case should include positive examples
            Assert.AreEqual("abc", Apex.Identifier.Parse(" abc "));
            Assert.AreEqual("Test123", Apex.Identifier.Parse("Test123"));

            // and negative ones
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("1"));
        }

        [Test]
        public void AKeywordIsNotAnIdentifier()
        {
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("class"));
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("public"));
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("private"));
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("static"));
        }

        [Test]
        public void ParameterDeclarationIsTypeAndNamePair()
        {
            var pd = Apex.ParameterDeclaration.Parse(" int a");
            Assert.AreEqual("int", pd.ParameterType);
            Assert.AreEqual("a", pd.ParameterName);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Test]
        public void ParameterDeclarationsIsACommaSeparaterListOfParameterDeclarations()
        {
            var pds = Apex.ParameterDeclarations.Parse(" int a, String b");
            Assert.AreEqual(2, pds.Count);

            var pd = pds[0];
            Assert.AreEqual("int", pd.ParameterType);
            Assert.AreEqual("a", pd.ParameterName);

            pd = pds[1];
            Assert.AreEqual("String", pd.ParameterType);
            Assert.AreEqual("b", pd.ParameterName);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Test]
        public void MethodParametersCanBeJustEmptyBraces()
        {
            var mp = Apex.MethodParameters.Parse(" () ");
            Assert.NotNull(mp.Parameters);
            Assert.False(mp.Parameters.Any());

            // unmatched braces, bad input, etc
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("("));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("(())"));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("Hello"));
        }

        [Test]
        public void MethodParametersIsCommaSeparatedParameterDeclarationsWithinBraces()
        {
            var mp = Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean c123 ) ");
            Assert.NotNull(mp.Parameters);
            Assert.AreEqual(3, mp.Parameters.Count);

            var pd = mp.Parameters[0];
            Assert.AreEqual("Integer", pd.ParameterType);
            Assert.AreEqual("a", pd.ParameterName);

            pd = mp.Parameters[1];
            Assert.AreEqual("char", pd.ParameterType);
            Assert.AreEqual("b", pd.ParameterName);

            pd = mp.Parameters[2];
            Assert.AreEqual("Boolean", pd.ParameterType);
            Assert.AreEqual("c123", pd.ParameterName);

            // bad input examples
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean ) "));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("123"));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("int a"));
        }

        [Test]
        public void MemberVisibilityCanBePublicOrPrivate()
        {
            Assert.AreEqual("public", Apex.MemberVisibility.Parse(" \n public "));
            Assert.AreEqual("private", Apex.MemberVisibility.Parse(" private \t"));

            // bad input
            Assert.Throws<ParseException>(() => Apex.MemberVisibility.Parse(" whatever "));
        }

        [Test]
        public void MethodDeclarationIsAMethodSignatureWithABlock()
        {
            // parameterless method
            var md = Apex.MethodDeclaration.Parse("void Test() {}");
            Assert.AreEqual("private", md.Visibility);
            Assert.AreEqual("void", md.ReturnType);
            Assert.AreEqual("Test", md.MethodName);
            Assert.True(md.Parameters.IsEmpty);

            // method with parameters
            md = Apex.MethodDeclaration.Parse(@"
            string Hello( String name, Boolean newLine )
            {
            } ");

            Assert.AreEqual("private", md.Visibility);
            Assert.AreEqual("string", md.ReturnType);
            Assert.AreEqual("Hello", md.MethodName);
            Assert.False(md.Parameters.IsEmpty);

            var mp = md.Parameters;
            Assert.AreEqual(2, mp.Parameters.Count);

            var pd = mp.Parameters[0];
            Assert.AreEqual("String", pd.ParameterType);
            Assert.AreEqual("name", pd.ParameterName);

            pd = mp.Parameters[1];
            Assert.AreEqual("Boolean", pd.ParameterType);
            Assert.AreEqual("newLine", pd.ParameterName);

            // method with visibility
            md = Apex.MethodDeclaration.Parse(@"
            public int Add(int x, int y, int z)
            {
            } ");

            Assert.AreEqual("public", md.Visibility);
            Assert.AreEqual("int", md.ReturnType);
            Assert.AreEqual("Add", md.MethodName);
            Assert.False(md.Parameters.IsEmpty);

            mp = md.Parameters;
            Assert.AreEqual(3, mp.Parameters.Count);

            pd = mp.Parameters[0];
            Assert.AreEqual("int", pd.ParameterType);
            Assert.AreEqual("x", pd.ParameterName);

            // invalid input
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void Test {}"));
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void AnotherTest()() {}"));
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void() {}"));
        }

        [Test]
        public void ClassDeclarationCanBeEmpty()
        {
            var cd = Apex.ClassDeclaration.Parse(" class Test {}");
            Assert.False(cd.Methods.Any());
            Assert.AreEqual("Test", cd.ClassName);

            // incomplete class declarations
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test {"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class {}"));
        }

        [Test]
        public void ClassDeclarationCanDeclareMethods()
        {
            var cd = Apex.ClassDeclaration.Parse(" class Program { void main() {} }");
            Assert.True(cd.Methods.Any());
            Assert.AreEqual("Program", cd.ClassName);

            var md = cd.Methods.Single();
            Assert.AreEqual("void", md.ReturnType);
            Assert.AreEqual("main", md.MethodName);
            Assert.True(md.Parameters.IsEmpty);

            // class declarations with bad methods
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test { void Main }"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class Apex { int main() }"));
        }
    }
}
