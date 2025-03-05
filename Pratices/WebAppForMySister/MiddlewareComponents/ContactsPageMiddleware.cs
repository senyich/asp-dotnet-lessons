namespace WebAppForMySister.MiddlewareComponents
{
    public class ContactsPageMiddleware
    {
        private readonly RequestDelegate next;
        public ContactsPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/contacts.html");
            await next.Invoke(context);
        }
    }
}
