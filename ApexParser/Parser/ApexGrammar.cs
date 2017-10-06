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
        // examples: a, Apex, code123
        protected internal virtual Parser<string> Identifier =>
        (
            from identifier in Parse.Identifier(Parse.Letter, Parse.LetterOrDigit)
            where !ApexKeywords.All.Contains(identifier)
            select identifier
        )
        .Token().Named("Identifier");

        // examples: /* default settings are OK */ //
        protected internal virtual CommentParser CommentParser { get; } = new CommentParser();

        // examples: int, void
        protected internal virtual Parser<string> PrimitiveType =>
            Parse.String(ApexKeywords.Int).Or(
            Parse.String(ApexKeywords.Boolean)).Or(
            Parse.String(ApexKeywords.Char)).Or(
            Parse.String(ApexKeywords.Void))
                .Token().Text().Named("PrimitiveType");

        // example: string name
        protected internal virtual Parser<ParameterSyntax> ParameterDeclaration =>
            from type in PrimitiveType.Or(Identifier)
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

        // examples: public, private, with sharing
        protected internal virtual Parser<string> Modifier =>
            Parse.String(ApexKeywords.Public).Or(
            Parse.String(ApexKeywords.Protected)).Or(
            Parse.String(ApexKeywords.Private)).Or(
            Parse.String(ApexKeywords.Static)).Or(
            Parse.String(ApexKeywords.Abstract)).Or(
            Parse.String(ApexKeywords.Final)).Or(
            Parse.String(ApexKeywords.Global)).Or(
            Parse.String(ApexKeywords.WebService)).Or(
            Parse.String(ApexKeywords.Override)).Or(
            Parse.String(ApexKeywords.Virtual)).Or(
            Parse.String(ApexKeywords.TestMethod)).Or(
            Parse.String(ApexKeywords.With).Token().Then(_ => Parse.String(ApexKeywords.Sharing)).Return("with_sharing")).Or(
            Parse.String(ApexKeywords.Without).Token().Then(_ => Parse.String(ApexKeywords.Sharing)).Return("without_sharing")).Or(
            Parse.String("todo?"))
                .Text().Token().Named("Modifier");

        // examples:
        // void Test() {}
        // public static void Hello() {}
        protected internal virtual Parser<MethodSyntax> MethodDeclaration =>
            from modifiers in Modifier.Many()
            from returnType in PrimitiveType.Or(Identifier)
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
            from @class in Parse.String(ApexKeywords.Class).Token()
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
