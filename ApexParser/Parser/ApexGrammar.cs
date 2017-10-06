using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.MetaClass;
using Sprache;

namespace ApexParser.Parser
{
    public class ApexGrammar
    {
        // TODO: import Apex keywords
        protected internal HashSet<string> Keywords { get; } = new HashSet<string>
        {
            "class", "public", "private", "static"
        };

        // examples: a, Apex, code123
        protected internal virtual Parser<string> Identifier =>
        (
            from identifier in Parse.Identifier(Parse.Letter, Parse.LetterOrDigit)
            where !Keywords.Contains(identifier)
            select identifier
        )
        .Token().Named("Identifier");

        // example: string name
        protected internal virtual Parser<ParameterSyntax> ParameterDeclaration =>
            from type in Identifier
            from name in Identifier
            select new ParameterSyntax(type, name);

        // example: int a, Boolean flag
        protected internal virtual Parser<List<ParameterSyntax>> ParameterDeclarations =>
            from first in ParameterDeclaration.Once()
            from rest in Parse.Char(',').Then(_ => ParameterDeclaration).Many()
            select first.Concat(rest).ToList();

        // example: (string a, char delimiter)
        protected internal virtual Parser<List<ParameterSyntax>> MethodParameters =>
            from openBrace in Parse.Char('(').Token()
            from param in ParameterDeclarations.Optional()
            from closeBrace in Parse.Char(')').Token()
            select param.GetOrElse(new List<ParameterSyntax>());

        // examples: public, private
        protected internal virtual Parser<string> Modifier =>
            Parse.String("public").Or(
            Parse.String("private")).Or(
            Parse.String("static"))
                .Text().Token().Named("Modifier");

        // examples:
        // void Test() {}
        // public static void Hello() {}
        protected internal virtual Parser<MethodSyntax> MethodDeclaration =>
            from modifiers in Modifier.Many()
            from returnType in Identifier
            from methodName in Identifier
            from parameters in MethodParameters
            from openBrace in Parse.Char('{').Token()
            from closeBrace in Parse.Char('}').Token()
            select new MethodSyntax
            {
                Modifiers = modifiers.ToList(),
                ReturnType = returnType,
                Identifier = methodName,
                MethodParameters = parameters
            };

        // example: class Program { void main() {} }
        protected internal virtual Parser<ClassSyntax> ClassDeclaration =>
            from modifiers in Modifier.Many()
            from @class in Parse.String("class").Token()
            from className in Identifier
            from openBrace in Parse.Char('{').Token()
            from methods in MethodDeclaration.Many()
            from closeBrace in Parse.Char('}').Token()
            select new ClassSyntax
            {
                Identifier = className,
                Modifiers = modifiers.ToList(),
                Methods = methods.ToList()
            };
    }
}
