using System.Collections.Generic;
using ApexParser.Lexer;

namespace ApexParser.MetaClass
{
    public class MethodSyntax : BaseSyntax
    {
        public MethodSyntax()
        {
            Kind = SyntaxType.Method;
        }

        public List<string> Attributes { get; set; } = new List<string>();

        public List<string> Modifiers { get; set; } = new List<string>();

        public TypeSyntax ReturnType { get; set; }

        public string Identifier { get; set; }

        public List<ParameterSyntax> MethodParameters { get; set; } = new List<ParameterSyntax>();

        public string CodeInsideMethod { get; set; }
    }
}