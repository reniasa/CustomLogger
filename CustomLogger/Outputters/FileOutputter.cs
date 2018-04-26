using CustomLogger.Enums;
using CustomLogger.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace CustomLogger.Outputters
{
    public class FileOutputter : LogBase, IOutputter
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private string filePath = AssemblyDirectory + "\\Log.txt";

        public void Log(string message, LogLevel logLevel)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(logLevel.ToString() + " - " + message);
                    streamWriter.Close();
                }
            }
        }
    }
}
