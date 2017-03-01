using NUnit.Framework;

namespace LogAn
{
    /// <summary>
    /// 以下是属性注入测试代码部分
    /// </summary>
    [TestFixture]
    public class LogAnalyzerPropertyInjectTests
    {
        [Test]
        public void IsValidFileName_SupportExtension_ReturnTrue()
        {
            //使用前面构造函数注入用的桩
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            LogAnalyzerPropertyInject log = new LogAnalyzerPropertyInject();
            log.ExtensionManager = myFakeManager;

            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.True(result);
        }
    }

}
