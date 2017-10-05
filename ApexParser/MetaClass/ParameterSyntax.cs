namespace ApexParser.MetaClass
{
    public class ParameterSyntax
    {
        public ParameterSyntax(string type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }
        public string Type { set; get; }
        public string Identifier { get; set; }
    }
}