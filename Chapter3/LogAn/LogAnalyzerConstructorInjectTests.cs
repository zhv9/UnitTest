using System;
using NUnit.Framework;

namespace LogAn
{


    /// <summary>
    /// 以下是测试代码部分
    /// </summary>
    [TestFixture]
    public class LogAnalyzerConstructorInjectTests
    {
        //测试返回true的情况
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

        //测试抛出异常的情况
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("This is fake");

            LogAnalyzerConstructorInject log =
                new LogAnalyzerConstructorInject(myFakeManager);
            bool result = log.IsValidLogFileName("anything.anyextension");

            //需要在被测方法外添加一个try-catch，并且在catch中返回false(根据需要可以对应修改catch和这个assert)
            Assert.False(result);
        }
    }


    //使用构造函数注入伪对象可能会带来问题：
    //如果被测试代码需要放置多个桩才能在没有依赖项的情况下正常工作，加入越来越多的构造函数或越来越多的构造函数参数，就变得很困难，还会降低代码可读性和可维护性。
    //public LogAnalyzer(IExtensionManager mgr, Ilog logger, IWebService service)这样多的参数会降低类的可维护性
    //解决方法是创建一个特殊类，包含初始化一个类的所有值。依赖项多的话，这个类还是会失控。
    //另一个方案是使用控制反转(Inversion of Control IoC)容器。

}
