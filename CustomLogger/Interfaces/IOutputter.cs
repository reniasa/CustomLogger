using CustomLogger.Enums;

namespace CustomLogger.Interfaces
{
    public interface IOutputter
    {
        void Log(string message, LogLevel logLevel);
    }
}
