using Chapter3.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    class LogAnalyzerPropertyInject
    {
        //属性注入，伪代码
        //public IExtensionManager Manager
        //{
        //    get { return m_manager; }
        //    set { m_manager = value; }
        //}
        //IExtensionManager m_manager

        //IsValidFileName(string)
        //{
        //    if (m_manager.IsValid(file))
        //    ...
        //}
        private IExtensionManager manager;
        public LogAnalyzerPropertyInject()
        {
            manager = new FileExtensionManager();
        }
        public IExtensionManager ExtensionManager
        {
            get { return manager; }
            set { manager = value; }
        }

        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName);
        }


        //下面两个是定义的实现类和对应抽象出来的接口
        //public interface IExtensionManager
        //{
        //    bool IsValid(string fileName);
        //}

        public class FileExtensionManager : IExtensionManager
        {
            public bool IsValid(string fileName)
            {
                //读取文件
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentException("filename has to be provided");
                }
                if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }

                return true;
            }
        }
    }

}
