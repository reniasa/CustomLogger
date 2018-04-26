using CustomLogger.Enums;
using CustomLogger.Interfaces;
using CustomLogger.Outputters;
using System;
using System.Diagnostics.Contracts;

namespace CustomLogger
{
    public class EventLogger 
    {
        private static IOutputter _outputter;
        public static void Log(LogTarget logTarget, LogLevel logLevel, string message)
        {
            Contract.Requires(message != string.Empty);
            Contract.Requires(message != null);

            switch (logTarget)
            {
                case LogTarget.CONSOLE:
                    _outputter = new ConsoleOutputter();
                    break;
                case LogTarget.FILE:
                    _outputter = new FileOutputter();
                    break;
                case LogTarget.SOCKET:
                    _outputter = new SocketOutputter();
                    break;
                
            }
            _outputter.Log(message, logLevel);
        }
    }
}

