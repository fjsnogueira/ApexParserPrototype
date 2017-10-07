namespace ApexParser.MetaClass
{
    public class ParameterSyntax
    {
        public ParameterSyntax(string type, string identifier)
            : this(new TypeSyntax(type), identifier)
        {
        }

        public ParameterSyntax(TypeSyntax type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }

        public TypeSyntax Type { get; set; }

        public string Identifier { get; set; }
    }
}