using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter3.LogAn;

namespace LogAn
{
    public class LogAnalyzerFactoryInject
    {
        private IExtensionManager manager;

        public LogAnalyzerFactoryInject()
        {
            manager = ExtensionManagerFactory.Create();
        }

        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName)
                   && Path.GetFileNameWithoutExtension(fileName).Length > 5;
        }
    }

    class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;

        public static IExtensionManager Create()
        {
            if (customManager != null)
                return customManager;
            return new FileExtensionManager();
        }

        public void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
