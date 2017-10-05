using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexParser.MetaClass
{
    public class ConstructorSyntax : BaseSyntax
    {
        public List<string> Attributes = new List<string>();
        public List<string> Modifiers = new List<string>();
        public string Identifier { get; set; }
        public List<ParameterSyntax> Parameters = new List<ParameterSyntax>();
        public string CodeInsideConstructor { get; set; }

        public ConstructorSyntax()
        {
            Kind = SyntaxType.Constructor;
        }
    }
}
