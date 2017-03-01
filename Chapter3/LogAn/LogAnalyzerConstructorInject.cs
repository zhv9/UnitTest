using Chapter3.LogAn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    ////构造函数注入，伪代码
    //ClassUnderTest(IExtensionManager mgr) 
    //
    //{ m_manager = mgr }

    //IExtensionManager m_manager;

    //IsValidFileName(string)
    //{
    //    if(m_manager.isvalid(file))
    //    ....
    //}

    class LogAnalyzerConstructorInject
    {
        //定义局部字段
        private IExtensionManager manager;

        //定义测试代码可以调用的构造函数
        public LogAnalyzerConstructorInject(IExtensionManager mgr)
        {
            manager = mgr;
        }

        public bool IsValidLogFileName(string fileName)
        {
            ////使用构造函数传入的IExtensionManager类
            //return manager.IsValid(fileName);

            //给上面代码增加try-catch块
            try
            {
                return manager.IsValid(fileName);
            }
            catch
            {
                return false;
            }
        }
    }

    //public interface IExtensionManager
    //{
    //    bool IsValid(string fileName);
    //}


    //使用构造函数注入伪对象可能会带来问题：
    //如果被测试代码需要放置多个桩才能在没有依赖项的情况下正常工作，加入越来越多的构造函数或越来越多的构造函数参数，就变得很困难，还会降低代码可读性和可维护性。
    //public LogAnalyzer(IExtensionManager mgr, Ilog logger, IWebService service)这样多的参数会降低类的可维护性
    //解决方法是创建一个特殊类，包含初始化一个类的所有值。依赖项多的话，这个类还是会失控。
    //另一个方案是使用控制反转(Inversion of Control IoC)容器。

}
