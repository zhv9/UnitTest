using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerAll
{
    public class LogAnalyzerAll
    {
        //在构造时，把伪对象和桩注入进来
        public LogAnalyzerAll(IWebService service, IEmailService email)
        {
            Email = email;
            Service = service;
        }

        public IWebService Service { get; set; }
        public IEmailService Email { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("文件名太短：" + fileName);
                }
                catch (Exception e)
                {
                    Email.SendEmail("someone@somewhere.com", "不能储存Log", e.Message);
                }
            }
        }
    }

    public class LogAnalyzerAllUseEmailInfo
    {
        //3. 使用EmailInfo后形参需要使用IEmailServiceUseEmailInfo来定义了
        public LogAnalyzerAllUseEmailInfo(IWebService service, IEmailServiceUseEmailInfo email)
        {
            Email = email;
            Service = service;
        }

        public IWebService Service { get; set; }
        public IEmailServiceUseEmailInfo Email { get; set; }

        //4. 使用EmailInfo后需要实例化一个EmailInfo，这里可以考虑用属性注入来对To和Subject插桩
        public EmailInfo EmailInfo { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("文件名太短：" + fileName);
                }
                catch (Exception e)
                {
                    EmailInfo = new EmailInfo
                    {
                        To = "someone@somewhere.com",
                        Subject = "不能储存Log",
                        Body = e.Message
                    };

                    //5. 发送邮件时参数就可以直接使用EmailInfo实体了
                    Email.SendEmail(EmailInfo);
                }
            }
        }
    }
}
