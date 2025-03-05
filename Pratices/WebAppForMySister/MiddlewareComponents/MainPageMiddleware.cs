namespace WebAppForMySister.MiddlewareComponents
{
    public class MainPageMiddleware
    {
        private readonly RequestDelegate next;
        public MainPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/index.html");
            await next.Invoke(context);
        }
    }
}
