﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ApexParser.ApexCodeFormatter;
using ApexParser.Lexer;
using ApexParser.MetaClass;

namespace ApexParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string myDevdir = @"C:\DevSharp";
            string apexCode = File.ReadAllText(myDevdir + @"\ApexParser\SalesForceApexSharp\src\classes\ClassDemo.cls");

            var apexCodeList = FormatApexCode.GetFormatedApexCode(apexCode);
            Console.WriteLine(apexCodeList);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}