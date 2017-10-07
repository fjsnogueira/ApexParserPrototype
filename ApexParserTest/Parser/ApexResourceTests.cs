using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApexParser.Parser;
using ApexParserTest.Properties;
using NUnit.Framework;
using Sprache;

namespace ApexParserTest.Parser
{
    [TestFixture]
    public class ApexResourceTests
    {
        private ApexGrammar Apex { get; } = new ApexGrammar();

        [Test, Ignore("TODO")]
        public void MethodsOneTest()
        {
            var cd = Apex.ClassDeclaration.Parse(Resources.MethodsOne);
        }
    }
}
