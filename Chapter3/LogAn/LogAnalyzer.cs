using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3.LogAn
{
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
    class FileExtensionManager:IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            //读取文件
        }
    }
    //然后定义新接口
    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }
}
