using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexParser.MetaClass
{
    public class ClassSyntax : BaseSyntax
    {
        public ClassSyntax()
        {
            Kind = SyntaxType.Class;
        }

        public List<string> Attributes { get; set; } = new List<string>();

        public List<string> Modifiers { get; set; } = new List<string>();

        public string Identifier { get; set; }

        public List<MethodSyntax> Methods { get; set; } = new List<MethodSyntax>();

        public List<PropertySyntax> Properties { get; set; } = new List<PropertySyntax>();
    }
}
