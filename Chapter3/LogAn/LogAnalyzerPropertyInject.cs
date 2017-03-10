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
            //调用类的时候构造，如果不使用下面的属性，则这个起作用。
            //这样就做到了使用属性是可选的，在不用属性的情况下正常使用。
            manager = new FileExtensionManager();
        }
        public IExtensionManager ExtensionManager
        {
            //在使用属性时，就可以把上面构造的FileExtensionManager() 覆盖掉了。
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
