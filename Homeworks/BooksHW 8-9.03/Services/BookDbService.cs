using FirstLesson.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FirstLesson.Services
{
    public class BookDbService
    {
        private SemaphoreSlim semaphore;
        private BookContext context;
        public BookDbService()
        {
            semaphore = new SemaphoreSlim(1);
            context = new BookContext();
        }
        public async Task AddBook(Book book)
        {
            await semaphore.WaitAsync();
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            finally { semaphore.Release(); }
        }
        public async Task<Book> GetBook(int id)
        {
            return context.Books.Where(b => b.Id == id).FirstOrDefault()!;
        }
        public async Task<ICollection<Book>> GetAllBooks()
        {
            return context.Books.ToList();
        }
    }
}
