using Microsoft.EntityFrameworkCore;
using WebAppForMySister.Data.Models;

namespace WebAppForMySister.Data
{
    public class Context : DbContext
    {
        public DbSet<ReviewModel> Reviews { get; set; }
        public Context()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=62.113.107.207;Port=5432;DataBase=reviews;Username=senya;Password=animenit2002");
        }
    }
}
