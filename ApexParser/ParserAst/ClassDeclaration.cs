using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Visitors;

namespace ApexParser.ParserAst
{
    public class ClassDeclaration
    {
        public string ClassName { get; set; }

        public List<MethodDeclaration> Methods { get; set; }

        public void Accept(BaseVisitor visitor)
        {
            visitor.VisitClassDeclaration(this);
        }
    }
}
