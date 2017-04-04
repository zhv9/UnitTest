using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerAll
{
    public class FakeWebService : IWebService
    {
        //存储交互数据
        public string LastError;
        //模拟抛出异常的情况
        public Exception ToThrow;

        public void LogError(string message)
        {
            LastError = message;
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }

    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;
        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }

    //6. 使用EmailInfo类时要使用对应的模拟类
    public  class FakeEmailServiceUseEmailInfo : IEmailServiceUseEmailInfo
    {
        public EmailInfo email = null;

        public void SendEmail(EmailInfo emailInfo)
        {
            email = emailInfo;
        }
    }
    //1. 首先要定义一个新的EmailInfo类
    public class EmailInfo
    {
        public string Body;
        public string To;
        public string Subject;
    }
}
