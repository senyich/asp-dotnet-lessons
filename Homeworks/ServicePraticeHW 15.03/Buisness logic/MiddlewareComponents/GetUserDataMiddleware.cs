using ServicePratice.Data.Models;
using ServicePratice.Interfaces;

namespace ServicePratice.MiddlewareComponents
{
    public class GetUserDataMiddleware
    {
        private RequestDelegate next;
        public GetUserDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IDbService<User> dbService, IEncrypterService encrypter, IVerificationService<User> verificator, ILoggerService logger)
        {
            var formData = context.Request.Query;
            context.Response.ContentType = "text/html; charset=utf-8";
            var username = formData["username"];
            var password = formData["password"];
            var typeOfAuth = formData["type"];
            logger.Log("GetUserDataMiddleware", "Получены данные от пользователя", DateTime.Now);
            string passwordHash = encrypter.Encrypt(password);
            var user = new User() { Username = username, HashedPassword = passwordHash };
            switch (typeOfAuth)
            {
                case "Войти":
                    logger.Log("GetUserDataMiddleware", "Попытка аутентификации", DateTime.Now);
                    var dbUser = await dbService.GetEntityByValue(user.Username);
                    if (await verificator.CompareEntities(dbUser, user))
                    {
                        await context.Response.SendFileAsync("Pages/account.html"); 
                        logger.Log("GetUserDataMiddleware", "Пользователь успешно зашел в аккаунт", DateTime.Now);
                    }
                    else
                    {
                        await context.Response.SendFileAsync("Pages/error.html");
                        logger.Log("GetUserDataMiddleware", "Аутентификация не удалась", DateTime.Now);
                    }
                    break;
                case "Зарегистрироваться":
                    try
                    {
                        logger.Log("GetUserDataMiddleware", "Попытка регистрации", DateTime.Now);
                        await Console.Out.WriteLineAsync(user.Username);
                        await Console.Out.WriteLineAsync(user.HashedPassword);
                        await context.Response.SendFileAsync("Pages/account.html");
                        await dbService.AddEntity(user);
                        logger.Log("GetUserDataMiddleware", "Пользователь успешно зарегистрировался", DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        logger.Log("GetUserDataMiddleware", "При регистрации произошла ошибка", DateTime.Now);
                        await context.Response.SendFileAsync("Pages/error.html");
                    }
                    break;
            }
            await next.Invoke(context);
        }
    }
}
