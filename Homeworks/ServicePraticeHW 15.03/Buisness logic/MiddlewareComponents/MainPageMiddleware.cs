using ServicePratice.Interfaces;

namespace ServicePratice.MiddlewareComponents
{
    public class MainPageMiddleware
    {
        private readonly RequestDelegate next;
        public MainPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, ILoggerService logger)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            logger.Log("MainPageMiddleware", "Пользователь перешел на форму регистрации", DateTime.Now);
            await context.Response.SendFileAsync("Pages/index.html");
            await next.Invoke(context);
        }
    }
}
