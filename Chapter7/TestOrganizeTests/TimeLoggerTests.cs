using System;
using NUnit.Framework;
using TestOrganize;
namespace TestOrganizeTests
{
    [TestFixture]
    public class TimeLoggerTests
    {
        [Test]
        public void SettingSystemTime_Always_ChangesTime()
        {
            //设置一个假日期
            SystemTime.Set(new DateTime(2000,1,1));
            string output = TimeLogger.CreateMessage("a");
            // 微软的和Nunit的StringAssert.Contains有差异，两个参数是相反的
            StringAssert.Contains("2000/1/1", output); 
        }

        [TearDown]
        public void AfterEachTest()
        {
            //每次测试结束时重置日期
            SystemTime.Reset();
        }
    }
}
