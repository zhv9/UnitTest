using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    public class SimpleParser
    {
        /// <summary>
        /// 输入是由0个或多个逗号分隔的数值组成的字符串，如果输入字符串不包含数值方法返回0
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int parserAndSum(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }
            if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                throw new InvalidOperationException("I can only handle 0 or 1 numbers for now!");
            }
        }
    }
}
