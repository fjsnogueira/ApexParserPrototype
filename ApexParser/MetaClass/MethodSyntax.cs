using System.Collections.Generic;
using ApexParser.Lexer;

namespace ApexParser.MetaClass
{
    public class MethodSyntax : BaseSyntax
    {
        public List<string> Attributes = new List<string>();
        public List<string> Modifiers = new List<string>();
        public string ReturnType { get; set; }
        public string Identifier { get; set; }

        public List<ParameterSyntax> MethodParameters = new List<ParameterSyntax>();

        public string CodeInsideMethod { get; set; }

        public MethodSyntax()
        {
            Kind = SyntaxType.Method;
        }
    }
}