using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAnalyzerAll
{
    [TestFixture]
    public class LogAnalyzerAllTest
    {
        [Test]
        public void Analyze_WebServiceThrow_SendsEmail()
        {
            //做一个假的WebService并给其中的ToThrow赋值，以便测试抛出异常的状况
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            //模拟一个邮件服务
            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzerAll log = new LogAnalyzerAll(stubService, mockEmail);
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            //对模拟的邮件服务中的数据做断言，测试是否确实的抛出了对应的异常
            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("不能储存Log", mockEmail.Subject);
            StringAssert.Contains("fake exception", mockEmail.Body);

            //使用多个断言会产生问题，第一个失败了其他的都不执行了。
            //通过创建EmailInfo对象，把要检验的三个属性都赋给它，就可以只用一个断言了(实际上不可以简单的使用Asert.AreEqual()来对两个对象作比较)
        }

        //
        [Test]
        public void Analyze_WebServiceThrow_SendsEmailUseEmailInfo()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            //7. 实例化使用EmailInfo类的模拟类
            FakeEmailServiceUseEmailInfo mockEmail = new FakeEmailServiceUseEmailInfo();

            //8. 实例化使用EmailInfo类的LogAnalyzerAllUseEmailInfo
            LogAnalyzerAllUseEmailInfo log = new LogAnalyzerAllUseEmailInfo(stubService, mockEmail);
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            //9. 初始化一个EmailInfo
            EmailInfo expectedEmail = new EmailInfo
            {
                To = "someone@somewhere.com",
                Subject = "不能储存Log",
                Body = "fake exception"
            };

            //10. 修改三个Assert为一个Assert，但实际上AreEqual只能比较字段，不能自动对一个对象中的所有字段比较。需要重写Equals方法。
            Assert.AreEqual(expectedEmail, mockEmail.email);
        }
    }
}
