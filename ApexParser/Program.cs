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
                //var apexTokens = ApexLexer.GetApexTokens(methodOne);
                //Console.WriteLine(JsonConvert.SerializeObject(methodList, Formatting.Indented));
             }

            Console.WriteLine("Done");
            Console.ReadLine();

            
        }

        public static ClassSyntax GetClass(string apexCode)
        {
            return null;
        }

    }
}

