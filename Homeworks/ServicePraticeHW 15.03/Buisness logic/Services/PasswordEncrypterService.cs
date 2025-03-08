using ServicePratice.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ServicePratice.Services
{
    public class PasswordEncrypterService : IEncrypterService
    {
        public string Encrypt(string text)
        {
            return text;
        }
        //так как в задании сказано, что пароль нужно просто закодировать)
    }
}
