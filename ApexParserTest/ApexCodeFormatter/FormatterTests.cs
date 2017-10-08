using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.ApexCodeFormatter;
using ApexParserTest.Properties;
using NUnit.Framework;
using static ApexParser.ApexCodeFormatter.FormatApexCode;

namespace ApexParserTest.ApexCodeFormatter
{
    [TestFixture]
    public class FormatterTests
    {
        [Test]
        public void ApexCodeFormatterFormatsClassOne()
        {
            var formatted = GetFormatedApexCode(Resources.ClassOne);
            Assert.AreEqual(Resources.ClassOne_Formatted, formatted);
        }

        [Test]
        public void ApexCodeFormatterFormatsClassTwo()
        {
            var formatted = GetFormatedApexCode(Resources.ClassTwo);
            Assert.AreEqual(Resources.ClassTwo_Formatted, formatted);
        }

        [Test]
        public void ApexCodeFormatterFormatsClassWithComments()
        {
            var formatted = GetFormatedApexCode(Resources.ClassWithComments);
            Assert.AreEqual(Resources.ClassWithComments_Formatted, formatted);
        }

        [Test]
        public void FormaterTestUsingExistingClass()
        {
            string apexCodeInput = File.ReadAllText(@"C:\DevSharp\ApexParser\SalesForceApexSharp\src\classes\FormatDemoInput.cls");
            string apexExpectedCode = File.ReadAllText(@"C:\DevSharp\ApexParser\SalesForceApexSharp\src\classes\FormatDemoOutPut.cls");
            var formatedApexCode = FormatApexCode.GetFormatedApexCode(apexCodeInput);

            // Change the name of the class so Test does not Fail just because of ClassName
            formatedApexCode = formatedApexCode.Replace("FormatDemoInput", "FormatDemoOutPut");

            List<string> apexCodeInputList = formatedApexCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            List<string> apexExpectedCodeList = apexExpectedCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            for (int i = 0; i < apexExpectedCodeList.Count; i++)
            {
                Assert.AreEqual(apexExpectedCodeList[i], apexCodeInputList[i]);
            }
        }
    }
}
