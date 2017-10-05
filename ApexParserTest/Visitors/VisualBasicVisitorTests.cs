﻿using System;
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
    public class VisualBasicVisitorTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Fact]
        public void EmptyClassDeclarationIsFormatted()
        {
            var cd = Apex.ClassDeclaration.Parse("class Test {}");
            var result = VisualBasicCodeGenerator.Generate(cd);

            Assert.Equal(
@"Class Test
End Class
", result);
        }

        [Fact]
        public void NonEmptyClassDeclarationIsFormatted()
        {
            var cd = Apex.ClassDeclaration.Parse("class Program{void Main(string arg){}}");
            var result = VisualBasicCodeGenerator.Generate(cd);

            Assert.Equal(
@"Class Program
    Sub Main(arg As string)
    End Sub
End Class
", result);
        }

    }
}
