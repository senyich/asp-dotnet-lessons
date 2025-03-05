
namespace DepencyContainer.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void PrintBooks();
        void SaveToFile(string filePath);
        void LoadFromFile(string filePath, int emptyLineSeparator);
    }
    public class BookService : IBookService
    {
        private List<Book> books;
        public BookService() { books = new List<Book>(); }
        public void AddBook(Book book) => books.Add(book);
        public void PrintBooks()
        {
            foreach (var book in books)
                Console.WriteLine(book);
        }
        public void SaveToFile(string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            using StreamWriter sw = new(fs);
            foreach (var book in books)
            {
                sw.WriteLine(book.Title);
                sw.WriteLine(book.Author);
                sw.WriteLine(book.Description);
                sw.WriteLine(book.Year);
                sw.WriteLine(book.ElseInfo);
                sw.WriteLine();
            }
        }
        public void LoadFromFile(string filePath, int lineSeparator)//решение не сильно красивое, но для примера пойдет
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("файл не найден");
                return;
            }
            books.Clear();
            var lines = File.ReadAllLines(filePath);
            List<string> bookData = new();
            int lineCounter = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    lineCounter++;
                    if (lineCounter == lineSeparator)
                    {
                        if (bookData.Count >= 5)
                        {
                            books.Add(new Book
                            {
                                Title = bookData[0],
                                Author = bookData[1],
                                Description = bookData[2],
                                Year = int.Parse(bookData[3]),
                                ElseInfo = bookData[4]
                            });
                        }
                        bookData.Clear();
                        lineCounter = 0;
                    }
                }
                else
                {
                    lineCounter = 0;
                    bookData.Add(line);
                }
            }
        }
    }
}
