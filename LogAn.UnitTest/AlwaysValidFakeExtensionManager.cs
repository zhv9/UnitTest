using System;
using NUnit.Framework;
using Chapter3.LogAn;

namespace LogAn.UnitTest
{
    //��������Ƿ���true�ļ�׮����
    //ʹ��Fake˵�������Ķ���������һ�����󣬼ȿ�������ģ�����Ҳ��������׮
    public class AlwaysValidFakeExtensionManager: IExtensionManager
    {
        //ʵ��IExtensionManager�ӿ�
        public bool IsValid(string fileName)
        {
            return true;
        }
    }

    ////���캯��ע��
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
