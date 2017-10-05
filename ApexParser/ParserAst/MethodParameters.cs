using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Visitors;

namespace ApexParser.ParserAst
{
    public class MethodParameters
    {
        public List<ParameterDeclaration> Parameters { get; set; }

        public bool IsEmpty =>
            Parameters == null || !Parameters.Any();

        public void Accept(BaseVisitor visitor)
        {
            visitor.VisitMethodParameters(this);
        }
    }
}
