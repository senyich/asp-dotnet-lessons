namespace WebAppForMySister.Services
{
    public class RequestDelegateService
    {
        public RequestDelegateService() { }
        public async Task HandleMainPageRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/index.html");
        }
        public async Task HandleFeedbackPageRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/feedback.html");
        }
        public async Task HandlePortfolioPageRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/portfolio.html");
        }
    }
}
