using System;
using System.Configuration;
using System.IO;

namespace CastleWindsor_AOP_WCF
{
    public static class TextLogHelper
    {
        public static void WriteLog(string text)
        {
            if (!Directory.Exists(ConfigurationManager.AppSettings["logPath"]))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["logPath"]);
            }
            string filename = ConfigurationManager.AppSettings["logPath"] + "/" + DateTime.Now.ToString("yyyyMMdd") +
                              ".txt";
            using (var fs = new FileStream(filename, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + text);
                    }
                    else
                    {
                        sw.WriteLine(text);
                    }
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}