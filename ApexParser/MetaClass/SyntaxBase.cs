using System.Collections.Generic;


namespace ApexParser.MetaClass
{
    public class SyntaxBase
    {
        public List<SyntaxBase> ChildNodes = new List<SyntaxBase>();
        public List<string> CodeComments = new List<string>();

        public SyntaxType Kind { get; set; }
    }
}
