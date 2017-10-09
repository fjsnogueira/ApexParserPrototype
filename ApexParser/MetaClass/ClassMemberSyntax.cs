using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexParser.MetaClass
{
    public class ClassMemberSyntax : BaseSyntax
    {
        public ClassMemberSyntax(ClassMemberSyntax other = null)
        {
            if (other != null)
            {
                CodeComments = other.CodeComments;
                Attributes = other.Attributes;
                Modifiers = other.Modifiers;
            }
        }

        public List<string> Attributes { get; set; } = new List<string>();

        public List<string> Modifiers { get; set; } = new List<string>();
    }
}
