# ApexParser

This is my attempt at creating some thing like Roslyn for Salesforce APEX. Their are two parts to it a Lexer and an AST builder.

The Lexar takes APEX source code and create tokens based on RegEx

```csharp
var apexTokens = ApexLexer.GetApexTokens(apexCode);
```
