using FirstLesson.Services;
using Microsoft.AspNetCore.Http;

using FirstLesson.Models;
using System.Text.RegularExpressions;

namespace FirstLesson.Handlers
{
    public class RequestHandler
    {
        private BookDbService bookDbService;
        public RequestHandler()
        {
            bookDbService = new BookDbService();

        }
        public async Task SendMainPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/MainPage.html");
        }
        public async Task SendFormPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/AddBookPage.html");
        }
        public async Task SendBooksPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("Pages/AllBooks.html");
        }
        public async Task SendBooksAsJson(HttpContext context)
        {
            var books = await bookDbService.GetAllBooks();
            await context.Response.WriteAsJsonAsync(books);
        }
        public async Task SendBookAsJson(HttpContext context)
        {
            var id = int.Parse(context.Request.Path.ToString().Split("/").Last());
            var book = await bookDbService.GetBook(id);
            await context.Response.WriteAsJsonAsync(book);
        }
        public async Task AddBookFromForm(HttpContext context)
        {
            var form = context.Request;
            Console.WriteLine(form.Method);
            string name = form.Query["name"];
            string title = form.Query["title"];
            string author = form.Query["author"];
            string desc = form.Query["desc"];

            Console.WriteLine(name);
            Console.WriteLine(title);
            Console.WriteLine(author);
            Console.WriteLine(desc);
            var book = new Book { Title = title, Author = author, Description = desc };
            var books = await bookDbService.GetAllBooks();
            if(!books.Select(book => book.Title).Contains(book.Title))
                await bookDbService.AddBook(book);
            await SendMainPage(context);
        }
    }
}
