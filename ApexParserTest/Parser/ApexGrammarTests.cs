using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Parser;
using Sprache;
using Xunit;

namespace ApexParserTest.Parser
{
    public class ApexGrammarTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Fact]
        public void IdentifierIsALetterFollowedByALetterOrDigit()
        {
            // every test case should include positive examples
            Assert.Equal("abc", Apex.Identifier.Parse(" abc "));
            Assert.Equal("Test123", Apex.Identifier.Parse("Test123"));

            // and negative ones
            Assert.Throws<ParseException>(() => Apex.Identifier.Parse("1"));
        }

        [Fact]
        public void ParameterDeclarationIsTypeAndNamePair()
        {
            var pd = Apex.ParameterDeclaration.Parse(" int a");
            Assert.Equal("int", pd.ParameterType);
            Assert.Equal("a", pd.ParameterName);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Fact]
        public void ParameterDeclarationsIsACommaSeparaterListOfParameterDeclarations()
        {
            var pds = Apex.ParameterDeclarations.Parse(" int a, String b");
            Assert.Equal(2, pds.Count);

            var pd = pds[0];
            Assert.Equal("int", pd.ParameterType);
            Assert.Equal("a", pd.ParameterName);

            pd = pds[1];
            Assert.Equal("String", pd.ParameterType);
            Assert.Equal("b", pd.ParameterName);

            Assert.Throws<ParseException>(() => Apex.ParameterDeclaration.Parse("Hello!"));
        }

        [Fact]
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

        [Fact]
        public void MethodParametersIsCommaSeparatedParameterDeclarationsWithinBraces()
        {
            var mp = Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean c123 ) ");
            Assert.NotNull(mp.Parameters);
            Assert.Equal(3, mp.Parameters.Count);

            var pd = mp.Parameters[0];
            Assert.Equal("Integer", pd.ParameterType);
            Assert.Equal("a", pd.ParameterName);

            pd = mp.Parameters[1];
            Assert.Equal("char", pd.ParameterType);
            Assert.Equal("b", pd.ParameterName);

            pd = mp.Parameters[2];
            Assert.Equal("Boolean", pd.ParameterType);
            Assert.Equal("c123", pd.ParameterName);

            // bad input examples
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse(" (Integer a, char b,  Boolean ) "));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("123"));
            Assert.Throws<ParseException>(() => Apex.MethodParameters.Parse("int a"));
        }

        [Fact]
        public void MethodDeclarationIsAMethodSignatureWithABlock()
        {
            // parameterless method
            var md = Apex.MethodDeclaration.Parse("void Test() {}");
            Assert.Equal("void", md.ReturnType);
            Assert.Equal("Test", md.MethodName);
            Assert.True(md.Parameters.IsEmpty);

            // method with parameters
            md = Apex.MethodDeclaration.Parse(@"
            string Hello( String name, Boolean newLine )
            {
            } ");

            Assert.Equal("string", md.ReturnType);
            Assert.Equal("Hello", md.MethodName);
            Assert.False(md.Parameters.IsEmpty);

            var mp = md.Parameters;
            Assert.Equal(2, mp.Parameters.Count);

            var pd = mp.Parameters[0];
            Assert.Equal("String", pd.ParameterType);
            Assert.Equal("name", pd.ParameterName);

            pd = mp.Parameters[1];
            Assert.Equal("Boolean", pd.ParameterType);
            Assert.Equal("newLine", pd.ParameterName);

            // invalid input
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void Test {}"));
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void AnotherTest()() {}"));
            Assert.Throws<ParseException>(() => Apex.MethodDeclaration.Parse("void() {}"));
        }

        [Fact]
        public void ClassDeclarationCanBeEmpty()
        {
            var cd = Apex.ClassDeclaration.Parse(" class Test {}");
            Assert.False(cd.Methods.Any());
            Assert.Equal("Test", cd.ClassName);

            // incomplete class declarations
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test {"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class {}"));
        }

        [Fact]
        public void ClassDeclarationCanDeclareMethods()
        {
            var cd = Apex.ClassDeclaration.Parse(" class Program { void main() {} }");
            Assert.True(cd.Methods.Any());
            Assert.Equal("Program", cd.ClassName);

            var md = cd.Methods.Single();
            Assert.Equal("void", md.ReturnType);
            Assert.Equal("main", md.MethodName);
            Assert.True(md.Parameters.IsEmpty);

            // class declarations with bad methods
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse(" class Test { void Main }"));
            Assert.Throws<ParseException>(() => Apex.ClassDeclaration.Parse("class Apex { int main() }"));
        }
    }
}
