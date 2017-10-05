using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Visitors;

namespace ApexParser.ParserAst
{
    public class MethodDeclaration
    {
        public string ReturnType { get; set; }

        public string MethodName { get; set; }

        public MethodParameters Parameters { get; set; }

        public void Accept(BaseVisitor visitor)
        {
            visitor.VisitMethodDeclaration(this);
        }
    }
}
