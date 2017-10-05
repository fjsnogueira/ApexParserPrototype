using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.ParserAst;
using Sprache;

namespace ApexParser.Parser
{
    public class ApexGrammar
    {
        // examples: a, Apex, code123
        protected internal virtual Parser<string> Identifier =>
            Parse.Letter.AtLeastOnce().Text().Then(h =>
            Parse.LetterOrDigit.Many().Text().Select(t => h + t)).Token();

        // example: string name
        protected internal virtual Parser<ParameterDeclaration> ParameterDeclaration =>
            from type in Identifier
            from name in Identifier
            select new ParameterDeclaration
            {
                ParameterType = type,
                ParameterName = name
            };

        // example: int a, Boolean flag
        protected internal virtual Parser<List<ParameterDeclaration>> ParameterDeclarations =>
            from first in ParameterDeclaration.Once()
            from rest in Parse.Char(',').Then(_ => ParameterDeclaration).Many()
            select first.Concat(rest).ToList();

        // example: (string a, char delimiter)
        protected internal virtual Parser<MethodParameters> MethodParameters =>
            from openBrace in Parse.Char('(').Token()
            from param in ParameterDeclarations.Optional()
            from closeBrace in Parse.Char(')').Token()
            select new MethodParameters
            {
                Parameters = param.GetOrElse(Enumerable.Empty<ParameterDeclaration>()).ToList()
            };

        // example: void Test() {}
        protected internal virtual Parser<MethodDeclaration> MethodDeclaration =>
            from returnType in Identifier
            from methodName in Identifier
            from parameters in MethodParameters
            from openBrace in Parse.Char('{').Token()
            from closeBrace in Parse.Char('}').Token()
            select new MethodDeclaration
            {
                ReturnType = returnType,
                MethodName = methodName,
                Parameters = parameters
            };

        // example: class Program { void main() {} }
        protected internal virtual Parser<ClassDeclaration> ClassDeclaration =>
            from @class in Parse.String("class").Token()
            from className in Identifier
            from openBrace in Parse.Char('{').Token()
            from methods in MethodDeclaration.Many()
            from closeBrace in Parse.Char('}').Token()
            select new ClassDeclaration
            {
                ClassName = className,
                Methods = methods.ToList()
            };
    }
}
