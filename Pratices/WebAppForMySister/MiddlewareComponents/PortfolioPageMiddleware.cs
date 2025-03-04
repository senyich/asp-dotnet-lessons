namespace WebAppForMySister.MiddlewareComponents
{
    public class PortfolioPageMiddleware
    {
        private readonly RequestDelegate next;
        public PortfolioPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/portfolio.html");
            await next.Invoke(context);
        }
    }
}
