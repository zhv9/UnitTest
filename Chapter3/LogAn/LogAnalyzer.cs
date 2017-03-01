using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3.LogAn
{
    //这个类在后面的实践中实际是没有用的
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            ////使用抽取出来的类
            //FileExtensionManager mgr =
            //    new FileExtensionManager();

            //定义这个接口的类型变量
            IExtensionManager mgr =
                new FileExtensionManager();

            return mgr.IsValid(fileName);
        }
    }

    //首先定义出这个抽取的类
    //定义完接口后实现这个接口
    public class FileExtensionManager:IExtensionManager
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

    ////然后定义新接口
    //后面将接口提出来放到单独类中，以便调用
    //public interface IExtensionManager
    //{
    //    bool IsValid(string fileName);
    //}
}
