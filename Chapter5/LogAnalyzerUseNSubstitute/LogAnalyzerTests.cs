using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LogAnalyzerUseNSubstitute
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        //使用手工伪对象进行测试
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            //下面这句后面会被隔离框架替换掉
            FakeLogger logger=new FakeLogger();

            LogAnalyzer analyzer=new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            //下面这句后面会被隔离框架替换掉
            StringAssert.Contains("too short", logger.LastError);
        }

        //使用NSubstitute生成的动态伪对象来测试
        [Test]
        public void Analyze_TooShortFileName_UseNSub_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();
            LogAnalyzer analyzer=new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");
            //使用NSub的API设置预期字符串，Received()这个方法在什么对象上调用，就会返回和这个对象同样类型的对象，但实际上是在声明断言对象。
            //如果不加Received()，伪对象就会认为这个调用是产品代码发出的。
            //使用Received()，就是在询问它后面的这个LogError是否调用过。
            logger.Received().LogError("Filename too short: a.txt");
        }

        //模拟值：使用动态伪对象生成一个桩，提供被测试系统需要的值
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            //强制方法调用时返回一个假值
            fakeRules.IsValidLogFileName("strict.txt").Returns(true);

            //因为调用了“fakeRules.IsValidLogFileName("strict.txt")”所以根据框架设置，返回了true
            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }

        //使用参数匹配器：不用管参数是什么，方法都返回一个假值
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument2()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            //这个Arg.Any<string>()就是参数匹配器，只要是string都会返回一个假值(例子里是true)
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("anything.txt"));
        }

        //使用NSub模拟异常
        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            //When方法必须使用Lambda表达式，其中x代表要改变行为的伪对象，context包含调用的参数值
            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                .Do(context=>{throw new Exception("fake exception");});

            Assert.Throws<Exception>(()=>fakeRules.IsValidLogFileName("anything"));
        }
    }

    class FakeLogger : ILogger
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }


}
