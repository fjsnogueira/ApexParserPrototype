namespace ApexParser.Lexer
{
    public class TokenDefinition
    {
        public readonly RegexMatcher Matcher;
        public readonly TokenType TokenType;

        public TokenDefinition(string regex, TokenType tokenType)
        {
            Matcher = new RegexMatcher(regex);
            TokenType = tokenType;
        }
    }
}
