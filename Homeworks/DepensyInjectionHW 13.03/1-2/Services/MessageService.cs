using Models;
using System.Reflection;

namespace Services
{
    public class MessageService : IMessageService
    {
        public string GenerateMessage(string msg) => (msg);
        public string GenerateMessage(string msg, string sender) => ($"[{sender}]: {msg}");
    }
    public interface IMessageService
    {
        string GenerateMessage(string msg);
        string GenerateMessage(string msg, string sender);
    }

}
