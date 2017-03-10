using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn
{
    public class LogAnalyzerFactoryInjectTests
    {
        public void IsValidFileName_SupportedExtension_ReturnTrue()
        {
            //设置要使用的桩，并给其赋值使其返回True
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            ExtensionManagerFactory factory = new ExtensionManagerFactory();
            factory.SetManager(myFakeManager);
            LogAnalyzerFactoryInject log = new LogAnalyzerFactoryInject();
            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.True(result);
        }
    }
}
