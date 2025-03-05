using Services;
using Models;
namespace Middlewares
{
    public class ShowPersonMiddleware
    {
        public readonly RequestDelegate next;
        public ShowPersonMiddleware (RequestDelegate next)
        { 
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IMessageService service)
        {

            context.Response.ContentType = "text/html;charset=utf-8";
            Person person = new Programmer(Position.Junior, "Senya", "Neshetin", 17);
            await context.Response.WriteAsync($"<h1>{service.GenerateMessage(person.ToString())}</h1>");
            await next.Invoke(context);
        }
    }
}
