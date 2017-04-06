using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LogAnalyzerUseNSubstitute
{
    [TestFixture]
    public class LogAnalyzer3Tests
    {
        //测试带有属性的对象
        //在调用WebService.Write方法时，使用了一个带有severity和message属性的ErrorInfo对象。
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            //1. 创建伪对象
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            //2. 对桩做设置
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            //3. 给被测方法注入桩和模拟对象
            var analyzer = new LogAnalyzer3(stubLogger, mockWebService);
            analyzer.MinNameLength = 8;
            analyzer.Analyze("short.txt");

            //4. 对模拟对象进行检查
            //使用and操作符创建比较复杂的预期结果，这里就是和检查单个值不一样的地方
            mockWebService.Received().Write(Arg.Is<ErrorInfo>(info =>
                info.Severity == 1000 && info.Message.Contains("fake exception")));
        }

        //对整个对象做比较
        //在上一章就没比较成功，因为需要重写objects.Equals()方法
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzer3(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("test.txt");

            //直接比较对象有个问题是一般会返回false，必须实现Equals()方法才能正确比较
            var expected = new ErrorInfo(1000, "fake exception");
            //这里断言是否得到了同样的对象(expected)，本质上用的就是assert.equals()
            mockWebService.Received().Write(expected);
        }
    }
}
