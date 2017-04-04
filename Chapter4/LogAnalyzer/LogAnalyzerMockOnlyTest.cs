using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAnalyzer
{
    public class LogAnalyzerMockOnlyTest
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //先实例化伪对象
            FakeWebService mockService = new FakeWebService();
            //然后使用实例化LogAnalyzer并用伪对象构造
            LogAnalyzerMockOnly log = new LogAnalyzerMockOnly(mockService);
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);
            //对模拟对象断言，模拟对象中的LastError记录了调用log.Analyze是产生的错误值
            StringAssert.Contains("文件名太短：abc.ext", mockService.LastError);

            //断言没有写在模拟对象内部的原因是：
            //* 其他测试用例能够使用别的断言，重用这个模拟对象
            //* 断言写在伪造对象内部的话，测试代码的可读性和可维护性降低了。
        }
    }
}
