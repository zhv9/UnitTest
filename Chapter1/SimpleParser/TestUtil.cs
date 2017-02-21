using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    class TestUtil
    {
        public static void ShowProblem(string test,String message)
        {
            string msg = string.Format(@"---{0}---{1}---", test, message);
            Console.WriteLine(msg);
        }
    }
}
