using FirstLesson.Handlers;
using FirstLesson.Services;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

RequestHandler handler = new RequestHandler();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", handler.SendMainPage);
app.Map("/CreateBook", handler.SendFormPage);
app.Map("/CreateBook/BookAdded", handler.AddBookFromForm);
app.Map("/Books", handler.SendBooksPage);
app.Map("/Api", (appBuilder)=>
{
    appBuilder.Map("/Books", appBuilder =>
    {
        appBuilder.Run(handler.SendBooksAsJson);
    }); 
    appBuilder.Map("/Book", appBuilder =>
    {
        appBuilder.UseWhen(context =>
        {
            return int.TryParse(context.Request.Path.ToString().Split("/").Last(), out _);
        },
        appBuilder =>
        {
            appBuilder.Run(handler.SendBookAsJson);
        });
    });
});

app.Run();
