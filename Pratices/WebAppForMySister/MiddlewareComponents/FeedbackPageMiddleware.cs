namespace WebAppForMySister.MiddlewareComponents
{
    public class FeedbackPageMiddleware
    {
        private readonly RequestDelegate next;
        public FeedbackPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/feedback.html");
            await next.Invoke(context);
        }
    }
}
