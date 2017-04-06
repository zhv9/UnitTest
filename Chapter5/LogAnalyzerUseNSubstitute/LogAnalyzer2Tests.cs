using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LogAnalyzerUseNSubstitute
{
    //如果日志抛出异常，要通知WebService
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        //先进行手工模拟对象测试
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            //1. 先把模拟对象和桩搞出来
            FakeWebService mockWebService = new FakeWebService();
            FakeLogger2 stubLogger2 = new FakeLogger2();
            stubLogger2.WillThrow = new Exception("fake exception");

            //2. 然后给被测类注入
            var analyzer2 = new LogAnalyzer2(stubLogger2, mockWebService);

            analyzer2.MinNameLength = 8;
            string tooShortFileName = "abc.txt";
            analyzer2.Analyze(tooShortFileName);

            //3. 检查模拟对象是否被调用
            Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));
        }

        //使用NSubstitute测试的代码
        [Test]
        public void Analyze_LoggerThrows_UseNSubCallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            //无论输入什么都抛出异常
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            //生成对象，并给这个对象注入模拟对象和桩，然后执行analyze使其按桩的要求抛出异常
            var analyzer = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer.MinNameLength = 8;
            string tooShortFileName = "short.txt";
            analyzer.Analyze(tooShortFileName);

            //验证在测试中调用了Web服务的模拟对象，调用参数字符串包含"fake exception"
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }

    //使用手工测试的话，就要编写伪对象FakeWebService和FakeLogger2
    public class FakeWebService : IWebService
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }

        public void Write(ErrorInfo message)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeLogger2 : ILogger
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;
        public void LogError(string message)
        {
            LoggerGotMessage = message;

            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }

}
