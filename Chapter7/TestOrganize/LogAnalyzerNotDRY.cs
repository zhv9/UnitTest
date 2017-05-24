using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrganize
{
    public interface ILogger
    {
        void Log(string text);
    }

    public static class LoggingFacility
    {
        public static void Log(string text)
        {
            Logger.Log(text);
        }

        private static ILogger logger;

        public static ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
    }

    public class LogAnalyzer
    {
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                LoggingFacility.Log("File Name too short:" + fileName);
            }
        }
    }

    public class ConfigurationManager
    {
        public bool IsConfiguerd(string configName)
        {
            LoggingFacility.Log("checking" + configName);
            return true; //result;
        }
    }
}
