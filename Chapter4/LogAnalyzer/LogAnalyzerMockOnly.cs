using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer
{
    public class LogAnalyzerMockOnly
    {
        private IWebService service;

        public LogAnalyzerMockOnly(IWebService service)
        {
            this.service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                service.LogError("文件名太短：" + fileName);
            }
        }
    }
}
