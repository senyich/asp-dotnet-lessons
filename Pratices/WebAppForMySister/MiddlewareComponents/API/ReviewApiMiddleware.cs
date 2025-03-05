using WebAppForMySister.Data.Models;
using WebAppForMySister.Services;

namespace WebAppForMySister.MiddlewareComponents.API
{
    public class ShowReviewsMiddleware
    {
        private readonly RequestDelegate next;
        public ShowReviewsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IDbService<ReviewModel> dbService)
        {
            var entities = await dbService.GetAllEntities();
            await context.Response.WriteAsJsonAsync(entities);
            await next.Invoke(context);
        }
    }
    public class AddReviewApiMiddleware
    {
        private readonly RequestDelegate next;
        public AddReviewApiMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IDbService<ReviewModel> dbService)
        {
            try
            {
                var formData = context.Request;

                string name = formData.Query["name"];
                string discord = formData.Query["discord"];
                string content = formData.Query["content"];

                var entity = new ReviewModel() { Name = name, Discord = discord, Content = content };
                await dbService.AddEntity(entity);
                context.Response.Redirect("/");
                return;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}
