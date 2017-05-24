using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestOrganize;

namespace TestOrganizeTests
{
    [TestFixture]
    public class LogAnalyzerNotDryTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowException()
        {
            LogAnalyzer la =new LogAnalyzer();
            la.Analyze("myemptyfile.txt");
            //测试的其余部分
        }

        [TearDown]
        public void TearDown()
        {
            LoggingFacility.Logger = null;
        }
    }

    [TestFixture]
    public class ConfigurationManagerTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowException()
        {
            ConfigurationManager cm = new ConfigurationManager();
            bool configured = cm.IsConfiguerd("something");
            //方法的其他部分
        }

        [TearDown]//这个TearDown和上面一个的一样，所以可以进行重构，放入测试基类中
        public void TearDown()
        {
            LoggingFacility.Logger = null;
        }
    }
}
