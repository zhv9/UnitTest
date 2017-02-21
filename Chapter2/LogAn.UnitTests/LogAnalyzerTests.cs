using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer m_analyzer = null;
        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }

        //验证错误的代码
        [Test]
        public void IsValidLogFileName_NGMethod_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName_NGMethod("filewithbadextension.foo");

            Assert.False(result);
        }

        //反向验证不正确的后缀
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        //正向验证小写后缀
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }
        //正向验证，大写后缀
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }


        #region 参数化测试
        //通过TestCase传递多个参数
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidLogFileName_ValidExtension_ReturnTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }
        
        //使用TestCase的两个参数，并通过Assert.AreEqual
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.foo", false)]
        public void IsValidLogFileName_ValidExtension_ChecksThem(string file, bool expected)
        {
            //LogAnalyzer analyzer = new LogAnalyzer();
            //这里使用了m_analyzer，所以把上面那个注释掉了
            bool result = m_analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, result);
        }
        [TearDown]
        public void TearDown()
        {
            //这个只是为了说明SetUp和TearDown的，实际不这么做
            m_analyzer = null;
        }
        #endregion

        //[Test]
        //[ExpectedException(typeof(ArgumentException),
        //      ExpectedMessage = "filename has to be provided")]
        //public void IsValidLogFileName_EmptyFileName_ThrowsException()
        //{
        //    LogAnalyzer la = MakeAnalyzer();
        //    la.IsValidLogFileName(string.Empty);
        //}

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsFluent()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));

            Assert.That(ex.Message, Is.StringContaining("filename has to be provided"));
        }

        [Test]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName("badname.foo");

            Assert.IsFalse(la.WasLastFileNameValid);
        }

        //refactored from above
        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName(file);

            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }

    }
}
