using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
