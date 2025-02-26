using FirstHW;
using HtmlPages;
using System.Text.Json;

var books = new List<Book>
{
    new Book { Id = 1, Title = "Фид до крипов", Author = "Зед Мейнер", Description = "отсутствует", Year = 2021 },
    new Book { Id = 2, Title = "Как чиллить в лесу", Author = "Рамус Арамус", Description = "отсутствует", Year = 2022 },
    new Book { Id = 3, Title = "Как достич поверспайка", Author = "Инвалид (Ясуо)", Description = "отсутствует", Year = 2023 }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(RequestHandler);
app.Run();

async Task RequestHandler(HttpContext context)
{
    string path = context.Request.Path;
    switch (path)
    {
        case "/":
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(await Pages.GetDateTimePage());
            break; 
        case "/browser":
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(await Pages.GetBrowserInfoPage(context.Request.Headers["User-Agent"]));
            break; 
        case "/books":
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(await Pages.GetBooksPage(books));
            break;
        case string s when s.StartsWith("/book/"): //тут я устал верстать странички, поэтому не заморочился с стилями 
            var bookId = s.Split('/')[2];
            var book = books.FirstOrDefault(b => b.Id.ToString() == bookId);
            if (book != null)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                var json = JsonSerializer.Serialize(book);
                await context.Response.WriteAsync(json);
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("{\"error\": \"Book not found\"}");
            }
            break;
    }
}