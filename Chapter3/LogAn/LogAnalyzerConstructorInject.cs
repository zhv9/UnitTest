using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn
{
    class LogAnalyzerConstructorInject
    {
        //定义局部字段
        private IExtensionManager manager;

        //定义测试代码可以调用的构造函数
        public LogAnalyzerConstructorInject(IExtensionManager mgr)
        {
            manager = mgr;
        }

        public bool IsValidLogFileName(string fileName)
        {
            //使用构造函数传入的IExtensionManager类
            return manager.IsValid(fileName);
        }
    }

    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            //准备一个返回true的桩
            FakeExtensionManager myFakeManager =
                new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            //传入桩
            LogAnalyzerConstructorInject log =
                new LogAnalyzerConstructorInject(myFakeManager);
            bool result = log.IsValidLogFileName("short.ext");
            Assert.True(result);
        }
    }

    //定义一个最简单的桩
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}
