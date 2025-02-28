using FirstLesson.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstLesson
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Books.Add(new Book() { Title = "Война и мир", Author = "Л.Н.Толстой", Description = "Книга о войне с наполеоном" });
            Books.Add(new Book() { Title = "Бойцовский клуб", Author = "Чак Паланник", Description = "Потеряв все, мы находим себя" });
            Books.Add(new Book() { Title = "Учебник по математике", Author = "Сатана", Description = "Убейте меня" });
            Books.Add(new Book() { Title = "Как достичь поверспайка", Author = "Хасаге", Description = "пособие по League OF Legends" });
            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=62.113.107.207;Port=5432;DataBase=books;Username=senya;Password=animenit2002");
        }
    }
}
