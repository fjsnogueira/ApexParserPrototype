using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Parser;
using ApexParser.Visitors;
using Sprache;
using Xunit;

namespace ApexParserTest.Visitors
{
    public class ApexVisitorTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Fact]
        public void EmptyClassDeclarationIsFormatted()
        {
            var cd = Apex.ClassDeclaration.Parse("class Test {}");
            var result = ApexCodeGenerator.Generate(cd);

            Assert.Equal(
@"class Test
{
}
", result);
        }

        [Fact]
        public void NonEmptyClassDeclarationIsFormatted()
        {
            var cd = Apex.ClassDeclaration.Parse("class Program{void Main(string arg){}}");
            var result = ApexCodeGenerator.Generate(cd);

            Assert.Equal(
@"class Program
{
    void Main(string arg)
    {
    }
}
", result);
        }

    }
}
