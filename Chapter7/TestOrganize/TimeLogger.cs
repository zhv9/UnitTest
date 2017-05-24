using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrganize
{
    public static class TimeLogger
    {
        public static string CreateMessage(string info)
        {
            //使用SystemTime类的产品代码
            return SystemTime.Now.ToShortDateString() + " " + info;
        }
    }

    public class SystemTime
    {
        private static DateTime _date;
        //SystemTime可以修改当前时间
        public static void Set(DateTime custom)
        {
            _date = custom;
        }

        //也可以重置当前时间
        public static void Reset()
        {
            _date=DateTime.MinValue;
        }

        //如果设置了时间，SystemTime就返回假时间，否则返回真实的时间
        public static DateTime Now
        {
            get
            {
                if (_date != DateTime.MinValue)
                {
                    return _date;
                }
                return DateTime.Now;
            }
        }
    }
}
