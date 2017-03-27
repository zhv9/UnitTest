using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn
{
    [TestFixture]
    public class LogAnalyzerVirtualFactoryTest
    {
        [Test]
        public void OverrideTest()
        {
            //设置要使用的桩，并赋值
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            //创建被测试类的派生类实例
            LogAnalyzerVirtualFactoryOverride logan = new LogAnalyzerVirtualFactoryOverride(stub);
            bool result = logan.IsValidLogFileName("file.ext");
            Assert.True(result);
        }

    }
}
