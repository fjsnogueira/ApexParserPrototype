using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Visitors;

namespace ApexParser.ParserAst
{
    public class ParameterDeclaration
    {
        public string ParameterType { get; set; }

        public string ParameterName { get; set; }

        public void Accept(BaseVisitor visitor)
        {
            visitor.VisitParameterDeclaration(this);
        }
    }
}
