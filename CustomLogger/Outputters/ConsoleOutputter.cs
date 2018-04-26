using CustomLogger.Interfaces;
using System;
using CustomLogger.Enums;

namespace CustomLogger.Outputters
{
    public class ConsoleOutputter : LogBase, IOutputter
    {
        public void Log(string message, LogLevel logLevel)
        {
            lock (lockObj)
            {
                Console.WriteLine(logLevel + " - " + message);
            }
        }
    }
}
