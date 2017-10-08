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

            string apexLine = String.Empty;
            ;
            foreach (var apexToken in apexTokens)
            {
                // If we have a newline, start on new line
                if (apexToken.TokenType == TokenType.Return)
                {
                    apexCodeList.Add(apexLine.Trim());
                    apexLine = String.Empty;
                }
                // If we have a ';' then next line should be new
                else if (apexToken.TokenType == TokenType.StatmentTerminator)
                {
                    apexLine = apexLine + apexToken.Content;
                    apexCodeList.Add(apexLine.Trim());
                    apexLine = String.Empty;
                }
                // '{' and "}" should be on its own line
                else if (apexToken.TokenType == TokenType.OpenCurlyBrackets ||
                         apexToken.TokenType == TokenType.CloseCurlyBrackets)
                {
                    apexCodeList.Add(apexLine.Trim());
                    apexCodeList.Add(apexToken.Content);
                    apexLine = String.Empty;
                }
                else
                {
                    apexLine = apexLine + apexToken.Content;
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
            StringBuilder sb = new StringBuilder();
            int padding = 0;

            foreach (var apexCode in apexCodeList)
            {
                if (apexCode.Trim() == "{")
                {
                    padding = padding + 5;

                }
                else if (apexCode.Trim() == "}")
                {
                    padding = padding - 5;
                }
                sb.AppendLine(new String(' ', padding) + apexCode);
            }

            return sb.ToString();
        }
    }
}
