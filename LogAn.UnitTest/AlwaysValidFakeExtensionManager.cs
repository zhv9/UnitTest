using System;
using NUnit.Framework;
using Chapter3.LogAn;

namespace LogAn.UnitTest
{
    //这个是总是返回true的简单桩代码
    //使用Fake说明这个类的对象类似另一个对象，既可能用作模拟对象，也可能用作桩
    public class AlwaysValidFakeExtensionManager: IExtensionManager
    {
        //实现IExtensionManager接口
        public bool IsValid(string fileName)
        {
            return true;
        }
    }

    ////构造函数注入
    //ClassUnderTest(IExtensionManager mgr) 
    //
    //{ m_manager = mgr }

    //IExtensionManager m_manager;

    //IsValidFileName(string)
    //{
    //    if(m_manager.isvalid(file))
    //    ....
    //}


}
