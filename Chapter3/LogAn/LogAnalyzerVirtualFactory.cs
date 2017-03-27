using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter3.LogAn;

namespace LogAn
{
    public class LogAnalyzerVirtualFactory
    {
        /*
        //被测代码
        Virtual IExtensionManager getExtensionManager()
        {
            return 
            new FileExtensionManager()  ///manager
        }
         
        IsValidFileName(string)
        {
            IExtensionManager manager = getExtensionManager();
            if(manager.isvalid(file))   ///manager
            ...
        }
             
        //测试代码
        public IExtensionManager manager;

        override IExtensionManager getExtensionManager()
        {
            return
            manager  ///manager!!这里的Manager把new FileExtensionManager()替换掉了
        }
         
        IsValidFileName(string)
        {
            IExtensionManager manager = getExtensionManager();
            if(manager.isvalid(file))  ///manager
            ...
        }
             
         **/

        //这个工厂方法，被定义为虚函数，以便后面重写并注入伪对象
        protected virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }
    }

    //这个类就是用来测试的类，其中最重要的部分就是把工厂重写了，可以通过构造函数给这个重写的类注入依赖
    class LogAnalyzerVirtualFactoryOverride : LogAnalyzerVirtualFactory
    {
        //通过这个构造函数就可以把伪对象注入进来了
        public LogAnalyzerVirtualFactoryOverride(IExtensionManager mgr)
        {
            manager = mgr;
        }
        private IExtensionManager manager;
        //这里把原来类的工厂重写了，返回构造函数指定值
        protected override IExtensionManager GetManager()
        {
            return manager;
        }
    }

    //下面这个已经在外面定义好了，直接用就行了
    //internal class FakeExtensionManager : IExtensionManager
    //{
    //    //模拟返回true或false用的，需要测试时赋值
    //    public bool WillBeValid = false;

    //    //模拟返回异常的，需要测试时赋值
    //    public Exception WillThrow = null;
    //    public bool IsValid(string fileName)
    //    {
    //        if (WillThrow != null) { throw WillThrow; }

    //        return WillBeValid;
    //    }
    //}
}
