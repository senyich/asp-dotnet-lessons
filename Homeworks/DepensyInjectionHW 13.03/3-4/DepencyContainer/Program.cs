using Microsoft.Extensions.DependencyInjection;
using DepencyContainer.Services;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public string ElseInfo { get; set; }

    public override string ToString()
    {
        return $"Заголовок: {Title}\n" +
            $"Автор: {Author}\n" +
            $"Описание: {Description}\n" +
            $"Год: {Year}\n" +
            $"Прочая информация: {ElseInfo}\n";
    }
}

class Program
{
    static void Main()
    {
        string filePath = "books.txt";
        var serviceProvider = new ServiceCollection().AddSingleton<IBookService, BookService>()
            .BuildServiceProvider();
        var bookService = serviceProvider.GetService<IBookService>();

        bookService.AddBook(new Book { Title = "книга1", Author = "автор1", Description = "описание1", Year = 2020, ElseInfo = "жанр1" });
        bookService.AddBook(new Book { Title = "книга2", Author = "автор2", Description = "описание2", Year = 2007, ElseInfo = "факт2" });

        Console.WriteLine("Все книги:");
        bookService.PrintBooks();

        bookService.SaveToFile(filePath);
        Console.WriteLine("Книги сохранены в файл");

        bookService.LoadFromFile(filePath, 1);
        Console.WriteLine("Книги загружены с файла");
        bookService.PrintBooks();
    }
}