﻿using System;
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
        public void APrimitiveTypeIsOneOfSpecificKeywords()
        {
            Assert.AreEqual(ApexKeywords.Void, Apex.PrimitiveType.Parse(" void "));
            Assert.AreEqual(ApexKeywords.Int, Apex.PrimitiveType.Parse(" int "));
            Assert.AreEqual(ApexKeywords.Boolean, Apex.PrimitiveType.Parse(" boolean "));

            // these keywords aren't types
            Assert.Throws<ParseException>(() => Apex.PrimitiveType.Parse("class"));
            Assert.Throws<ParseException>(() => Apex.PrimitiveType.Parse("sharing"));
        }

        [Test]
        public void ParameterDeclarationIsTypeAndNamePair()
        {
            var pd = Apex.ParameterDeclaration.Parse(" int a");
            Assert.AreEqual("int", pd.Type);
            Assert.AreEqual("a", pd.Identifier);

            pd = Apex.ParameterDeclaration.Parse(" SomeClass b");
            Assert.AreEqual("SomeClass", pd.Type);
            Assert.AreEqual("b", pd.Identifier);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Test]
        public void ParameterDeclarationsIsACommaSeparaterListOfParameterDeclarations()
        {
            var pds = Apex.ParameterDeclarations.Parse(" int a, String b");
            Assert.AreEqual(2, pds.Count);

            var pd = pds[0];
            Assert.AreEqual("int", pd.Type);
            Assert.AreEqual("a", pd.Identifier);

            pd = pds[1];
            Assert.AreEqual("String", pd.Type);
            Assert.AreEqual("b", pd.Identifier);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Test]
        public void MethodParametersCanBeJustEmptyBraces()
        {
            var mp = Apex.MethodParameters.Parse(" () ");
            Assert.NotNull(mp);
            Assert.False(mp.Any());

            // unmatched braces, bad input, etc
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("("));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("(())"));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("Hello"));
        }

        [Test]
        public void MethodParametersIsCommaSeparatedParameterDeclarationsWithinBraces()
        {
            var mp = Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean c123 ) ");
            Assert.NotNull(mp);
            Assert.AreEqual(3, mp.Count);

            var pd = mp[0];
            Assert.AreEqual("Integer", pd.Type);
            Assert.AreEqual("a", pd.Identifier);

            pd = mp[1];
            Assert.AreEqual("char", pd.Type);
            Assert.AreEqual("b", pd.Identifier);

            pd = mp[2];
            Assert.AreEqual("Boolean", pd.Type);
            Assert.AreEqual("c123", pd.Identifier);

            // bad input examples
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean ) "));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("123"));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("int a"));
        }

        [Test]
        public void MemberVisibilityCanBePublicOrPrivate()
        {
            Assert.AreEqual("public", Apex.Modifier.Parse(" \n public "));
            Assert.AreEqual("private", Apex.Modifier.Parse(" private \t"));

            // bad input
            Assert.Throws<ParseException>(() => Apex.Modifier.Parse(" whatever "));
        }

        [Test]
        public void MethodDeclarationIsAMethodSignatureWithABlock()
        {
            // parameterless method
            var md = Apex.MethodDeclaration.Parse("void Test() {}");
            Assert.False(md.Modifiers.Any());
            Assert.False(md.MethodParameters.Any());
            Assert.AreEqual("void", md.ReturnType);
            Assert.AreEqual("Test", md.Identifier);

            // method with parameters
            md = Apex.MethodDeclaration.Parse(@"
            string Hello( String name, Boolean newLine )
            {
            } ");

            Assert.False(md.Modifiers.Any());
            Assert.AreEqual(2, md.MethodParameters.Count);
            Assert.AreEqual("string", md.ReturnType);
            Assert.AreEqual("Hello", md.Identifier);

            var mp = md.MethodParameters;
            Assert.AreEqual(2, mp.Count);

            var pd = mp[0];
            Assert.AreEqual("String", pd.Type);
            Assert.AreEqual("name", pd.Identifier);

            pd = mp[1];
            Assert.AreEqual("Boolean", pd.Type);
            Assert.AreEqual("newLine", pd.Identifier);

            // method with visibility
            md = Apex.MethodDeclaration.Parse(@"
            public int Add(int x, int y, int z)
            {
            } ");

            Assert.AreEqual(1, md.Modifiers.Count);
            Assert.AreEqual("public", md.Modifiers[0]);
            Assert.AreEqual("int", md.ReturnType);
            Assert.AreEqual("Add", md.Identifier);
            Assert.AreEqual(3, md.MethodParameters.Count);

            mp = md.MethodParameters;
            Assert.AreEqual(3, mp.Count);

            pd = mp[0];
            Assert.AreEqual("int", pd.Type);
            Assert.AreEqual("x", pd.Identifier);

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
            Assert.False(cd.Modifiers.Any());
            Assert.AreEqual("Test", cd.Identifier);

            // incomplete class declarations
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test {"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class {}"));
        }

        [Test]
        public void ClassDeclarationCanDeclareMethods()
        {
            var cd = Apex.ClassDeclaration.Parse(" class Program { void main() {} }");
            Assert.True(cd.Methods.Any());
            Assert.AreEqual("Program", cd.Identifier);

            var md = cd.Methods.Single();
            Assert.AreEqual("void", md.ReturnType);
            Assert.AreEqual("main", md.Identifier);
            Assert.False(md.MethodParameters.Any());

            // class declarations with bad methods
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test { void Main }"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class Apex { int main() }"));
        }

        [Test]
        public void ClassDeclarationCanHaveMultipleModifiers()
        {
            var cd = Apex.ClassDeclaration.Parse(" public with   sharing webservice class Program { }");
            Assert.False(cd.Methods.Any());
            Assert.AreEqual("Program", cd.Identifier);

            Assert.AreEqual(3, cd.Modifiers.Count);
            Assert.AreEqual("public", cd.Modifiers[0]);
            Assert.AreEqual("with_sharing", cd.Modifiers[1]);
            Assert.AreEqual("webservice", cd.Modifiers[2]);

            // class declarations with bad methods
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class with Test { }"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class sharing Test { }"));
        }
    }
}
