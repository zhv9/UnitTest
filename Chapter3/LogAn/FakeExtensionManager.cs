using Chapter3.LogAn;
using System;

namespace LogAn
{

    //定义一个最简单的桩，具有返回true、false和抛出异常的功能
    //使用Fake说明这个类的对象类似另一个对象，既可能用作模拟对象，也可能用作桩
    internal class FakeExtensionManager : IExtensionManager
    {
        //模拟返回true或false用的，需要测试时赋值
        public bool WillBeValid = false;

        //模拟返回异常的，需要测试时赋值
        public Exception WillThrow = null;
        public bool IsValid(string fileName)
        {
            if (WillThrow != null) { throw WillThrow; }

            return WillBeValid;
        }
    }


    //使用构造函数注入伪对象可能会带来问题：
    //如果被测试代码需要放置多个桩才能在没有依赖项的情况下正常工作，加入越来越多的构造函数或越来越多的构造函数参数，就变得很困难，还会降低代码可读性和可维护性。
    //public LogAnalyzer(IExtensionManager mgr, Ilog logger, IWebService service)这样多的参数会降低类的可维护性
    //解决方法是创建一个特殊类，包含初始化一个类的所有值。依赖项多的话，这个类还是会失控。
    //另一个方案是使用控制反转(Inversion of Control IoC)容器。

}
