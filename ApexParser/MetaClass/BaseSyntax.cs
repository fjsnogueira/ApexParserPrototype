using System.Collections.Generic;


namespace ApexParser.MetaClass
{
    public class BaseSyntax
    {
        public List<BaseSyntax> ChildNodes = new List<BaseSyntax>();
        public List<string> CodeComments = new List<string>();

        public SyntaxType Kind { get; set; }
    }
}
