namespace ApexParser.MetaClass
{
    public class ParameterSyntax
    {
        public TypeSyntax Type { set; get; }
        public string Identifier { get; set; }

        public ParameterSyntax(string type, string identifier)
            : this(new TypeSyntax(type), identifier)
        {
        }

        public ParameterSyntax(TypeSyntax type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }
    }
}