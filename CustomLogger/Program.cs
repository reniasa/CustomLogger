using System;

namespace CustomLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLogger.Log(Enums.LogTarget.CONSOLE, Enums.LogLevel.INFO, "Working Console!");
            EventLogger.Log(Enums.LogTarget.FILE, Enums.LogLevel.WARNING, "Working File!");
            EventLogger.Log(Enums.LogTarget.SOCKET, Enums.LogLevel.DEBUG, "Working Socket!");
            EventLogger.Log(Enums.LogTarget.CONSOLE, Enums.LogLevel.ALERT, "Everything working!");

            Console.ReadLine();
        }
    }
}
