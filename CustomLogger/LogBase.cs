namespace CustomLogger
{
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
    }
}
