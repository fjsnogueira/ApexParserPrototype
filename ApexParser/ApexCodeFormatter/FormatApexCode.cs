using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Lexer;

namespace ApexParser.ApexCodeFormatter
{
    public class FormatApexCode
    {
        public const int IndentSize = 5;

        public static string GetFormatedApexCode(string apexCode)
        {
            var formatedApexCode = FormatApexCodeNoIndent(apexCode);
            var indentedApexCode = IndentApexCode(formatedApexCode);
            return indentedApexCode;
        }

        public static List<string> FormatApexCodeNoIndent(string apexCode)
        {
            List<string> apexCodeList = new List<string>();

            var apexTokens = ApexLexer.GetApexTokens(apexCode);
            var multiLineCommentLevel = 0;
            var lastValidCommentPosition = 0;

            var validCommentPositions = new[]
            {
                TokenType.CloseCurlyBrackets,
                TokenType.StatementTerminator,
                TokenType.AccessModifier,
                TokenType.KwVoid
            };

            string apexLine = string.Empty;
            foreach (var apexToken in apexTokens)
            {
                // Reposition the comment at the start of the last statement
                if (apexToken.TokenType == TokenType.CommentLine && multiLineCommentLevel == 0)
                {
                    apexCodeList.Insert(lastValidCommentPosition, apexToken.Content.Trim());
                    lastValidCommentPosition++;
                    apexCodeList.Add(apexLine.Trim());
                    apexLine = string.Empty;
                }

                // If we have a newline, start on new line
                else if (apexToken.TokenType == TokenType.Return)
                {
                    apexCodeList.Add(apexLine.Trim());
                    apexLine = string.Empty;
                }

                // If we have a ';' then next line should be new
                else if (apexToken.TokenType == TokenType.StatementTerminator)
                {
                    apexLine = apexLine + apexToken.Content;
                    apexCodeList.Add(apexLine.Trim());
                    apexLine = string.Empty;
                }

                // '{' and "}" should be on its own line
                else if (apexToken.TokenType == TokenType.OpenCurlyBrackets ||
                         apexToken.TokenType == TokenType.CloseCurlyBrackets)
                {
                    apexCodeList.Add(apexLine.Trim());
                    apexCodeList.Add(apexToken.Content);
                    apexLine = string.Empty;
                }
                else
                {
                    apexLine = apexLine + apexToken.Content;
                }

                // Save the last statement starting position
                if (validCommentPositions.Contains(apexToken.TokenType))
                {
                    lastValidCommentPosition = apexCodeList.Count;
                }

                // Compute the multi-line comment nesting level
                else if (apexToken.TokenType == TokenType.CommentStart)
                {
                    multiLineCommentLevel++;
                }
                else if (apexToken.TokenType == TokenType.CommentEnd)
                {
                    multiLineCommentLevel--;
                }
            }

            List<string> newApexCodeList = new List<string>();
            foreach (var apecCodeLine in apexCodeList)
            {
                if (apecCodeLine.Length != 0)
                {
                    newApexCodeList.Add(apecCodeLine);
                }
            }

            return newApexCodeList;
        }

        public static string IndentApexCode(List<string> apexCodeList)
        {
            var sb = new StringBuilder();
            var needExtraLine = false;
            int padding = 0;

            foreach (var apexCode in apexCodeList)
            {
                if (apexCode.Trim() == "}")
                {
                    padding = padding - IndentSize;
                    needExtraLine = true;
                }
                else if (needExtraLine)
                {
                    sb.AppendLine();
                    needExtraLine = false;
                }

                sb.AppendLine(new string(' ', padding) + apexCode);

                if (apexCode.Trim() == "{")
                {
                    padding = padding + IndentSize;
                }
            }

            return sb.ToString();
        }
    }
}
