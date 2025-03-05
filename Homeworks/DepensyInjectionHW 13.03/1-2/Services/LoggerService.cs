namespace Services
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message) => Console.WriteLine(message);
    }
    public class FileLoggerService : ILoggerService
    {
        private static object locker = new object();
        public void Log(string message)
        {
            lock (locker)
            {
                using FileStream fs = new FileStream("info.txt", FileMode.Open, FileAccess.Write);
                using StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine(message);
            }
        }
    }
    public interface ILoggerService
    {
        void Log(string msg);
    }
}
