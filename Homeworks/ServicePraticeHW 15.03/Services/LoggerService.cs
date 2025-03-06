namespace ServicePratice.Services
{
    using Interfaces;
    using ServicePratice.Interfaces;

    public class LoggerService : ILoggerService
    {
        public LoggerService() { Console.ForegroundColor = ConsoleColor.Yellow; }
        public void Log(string message) => Console.WriteLine(message);
        public void Log(string sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{sender}]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.WriteLine();
        }     
        public void Log(string sender, string message, DateTime time)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{sender}]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message +" " + time.ToShortTimeString());
            Console.WriteLine();
        }
    }
}
