using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerAll
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    //2. 如果使用EmailInfo类来定义邮件结构，就得定一个对应的接口
    public interface IEmailServiceUseEmailInfo
    {
        void SendEmail(EmailInfo email);
    }
}
