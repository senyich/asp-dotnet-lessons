using Models;
using Services;

namespace Middlewares
{
    public class LoggerMiddleware
    {
        public readonly RequestDelegate next;
        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILoggerService service)
        {
            var person = new Programmer(Position.TeamLead, "Aleshka", "Popovich", 30);
            service!.Log(person.ToString());
            await next.Invoke(context);
        }
    }
}
