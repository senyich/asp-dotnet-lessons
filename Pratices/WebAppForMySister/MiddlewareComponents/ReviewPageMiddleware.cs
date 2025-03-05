namespace WebAppForMySister.MiddlewareComponents
{
    public class ReviewPageMiddleware
    {
        private readonly RequestDelegate next;
        public ReviewPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/review.html");
            await next.Invoke(context);
        }
    }
}
