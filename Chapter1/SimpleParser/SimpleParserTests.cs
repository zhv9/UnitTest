using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    class SimpleParserTests
    {
        public static void TestReturnsZeroWhenEmptyString()
        {
            //使用反射的API获得当前方法名
            string testName = MethodBase.GetCurrentMethod().Name;
            try
            {
                SimpleParser p = new SimpleParser();
                int result = p.parserAndSum(string.Empty);
                if (result != 0)
                {
                    Console.WriteLine(
                        @"SimpleParserTests.TestReturnsZeroWhenEmptyString:
                        ---
                        Parse and sum should have returned 0 on an empty string");

                    //调用辅助方法
                    TestUtil.ShowProblem(testName, "Parse and sum should have returned 0 on an empty string");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                TestUtil.ShowProblem(testName, e.ToString());
            }
        }
    }
}
