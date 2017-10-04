using System;
using System.Collections.Generic;
using System.IO;
using ApexParser.Lexer;
using ApexParser.MetaClass;

namespace ApexParser
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
            {
                string dirName = directoryInfo.FullName;
                string methodOne = File.ReadAllText(dirName + @"\ApexCode\MethodsTwo.txt");
                var apexTokens = ApexLexer.GetApexTokens(methodOne);
                var methodList = GetAllMethods(apexTokens);
                //Console.WriteLine(JsonConvert.SerializeObject(methodList, Formatting.Indented));
                Console.WriteLine(methodList.Count);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static List<MethodSyntax> GetAllMethods(List<Token> apexTokens)
        {
            int j = 0;

            List<MethodSyntax> methodList = new List<MethodSyntax>();

            MethodSyntax method = null;

            while (apexTokens.Count > j)
            {
                if (apexTokens[j].TokenType == TokenType.AccessModifier
                    && apexTokens[j + 1].TokenType == TokenType.KwTestMethod
                    && apexTokens[j + 2].TokenType == TokenType.KwStatic
                    && (apexTokens[j + 3].TokenType == TokenType.Word || apexTokens[j + 3].TokenType == TokenType.ClassNameGeneric || apexTokens[j + 3].TokenType == TokenType.KwVoid)
                    && apexTokens[j + 4].TokenType == TokenType.Word
                    && apexTokens[j + 5].TokenType == TokenType.OpenBrackets
                    && apexTokens[j + 6].TokenType == TokenType.CloseBrackets)
                {

                    method = new MethodSyntax
                    {
                        ReturnType = apexTokens[j + 2].Content,
                        Identifier = apexTokens[j + 3].Content,
                    };
                    method.Attributes.Add(apexTokens[j].Content);
                    method.Modifiers.Add(apexTokens[j + 1].Content);
                    methodList.Add(method);
                    j = j + 7;
                }
                else if (apexTokens[j].TokenType == TokenType.Attrubute
                    && apexTokens[j + 1].TokenType == TokenType.AccessModifier
                    && apexTokens[j + 2].TokenType == TokenType.KwStatic
                    && (apexTokens[j + 3].TokenType == TokenType.Word || apexTokens[j + 3].TokenType == TokenType.ClassNameGeneric || apexTokens[j + 3].TokenType == TokenType.KwVoid)
                    && apexTokens[j + 4].TokenType == TokenType.Word
                    && apexTokens[j + 5].TokenType == TokenType.OpenBrackets
                    && apexTokens[j + 6].TokenType == TokenType.CloseBrackets)
                {

                    method = new MethodSyntax
                    {
                        ReturnType = apexTokens[j + 2].Content,
                        Identifier = apexTokens[j + 3].Content,
                    };
                    method.Attributes.Add(apexTokens[j].Content);
                    method.Modifiers.Add(apexTokens[j + 1].Content);
                    methodList.Add(method);
                    j = j + 7;
                }
                else if (apexTokens[j].TokenType == TokenType.AccessModifier
                    && (apexTokens[j + 1].TokenType == TokenType.Word || apexTokens[j + 1].TokenType == TokenType.ClassNameGeneric || apexTokens[j + 1].TokenType == TokenType.KwVoid)
                    && apexTokens[j + 2].TokenType == TokenType.Word
                    && apexTokens[j + 3].TokenType == TokenType.OpenBrackets
                    && apexTokens[j + 4].TokenType == TokenType.CloseBrackets)
                {

                    method = new MethodSyntax
                    {
                        ReturnType = apexTokens[j + 1].Content,
                        Identifier = apexTokens[j + 2].Content,
                    };
                    method.Modifiers.Add(apexTokens[j].Content);
                    methodList.Add(method);
                    j = j + 5;
                }

                else if ((apexTokens[j].TokenType == TokenType.Word || apexTokens[j].TokenType == TokenType.ClassNameGeneric || apexTokens[j].TokenType == TokenType.KwVoid)
                    && apexTokens[j + 1].TokenType == TokenType.Word
                    && apexTokens[j + 2].TokenType == TokenType.OpenBrackets
                    && apexTokens[j + 3].TokenType == TokenType.CloseBrackets)
                {

                    method = new MethodSyntax
                    {
                        ReturnType = apexTokens[j].Content,
                        Identifier = apexTokens[j + 1].Content,
                    };
                    methodList.Add(method);
                    j = j + 4;
                }

                else
                {
                    if (method != null)
                    {
                        //method.TokenList.Add(apexTokens[j]);
                    }
                    j++;
                }
            }

            return methodList;
        }
    }
}

