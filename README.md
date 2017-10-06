# ApexParser

[![Build status](https://ci.appveyor.com/api/projects/status/t5xph4j072w4c4x7?svg=true)](https://ci.appveyor.com/project/yallie/apexparser)

This is my attempt at creating some thing like Roslyn for Salesforce APEX. Their are two parts to it a Lexer and an AST builder.

The Lexar takes APEX source code and create tokens based on RegEx

```csharp
var apexTokens = ApexLexer.GetApexTokens(apexCode);
```
