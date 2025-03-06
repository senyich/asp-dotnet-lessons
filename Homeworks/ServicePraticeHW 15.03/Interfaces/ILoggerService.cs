namespace ServicePratice.Interfaces
{
    public interface ILoggerService
    {
        void Log(string message);
        void Log(string sender, string message);
        void Log(string sender, string message, DateTime time);
    }
}
