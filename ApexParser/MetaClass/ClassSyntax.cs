using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexParser.MetaClass
{
    public class ClassSyntax : BaseSyntax
    {
        public List<string> Attributes = new List<string>();
        public List<string> Modifiers = new List<string>();
        public string Identifier { get; set; }
        public List<MethodSyntax> Methods = new List<MethodSyntax>();

        public ClassSyntax()
        {
            Kind = SyntaxType.Class;
        }
    }
}
