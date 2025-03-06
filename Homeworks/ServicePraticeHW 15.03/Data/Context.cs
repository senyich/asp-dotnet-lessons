using Microsoft.EntityFrameworkCore;
namespace ServicePratice.Data
{
    using Models;
    namespace WebAppForMySister.Data
    {
        public class Context : DbContext
        {
            public DbSet<User> Users { get; set; }
            public Context()
            {
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=62.113.107.207;Port=5432;DataBase=PraticeUserData;Username=senya;Password=animenit2002");
            }
        }
    }

}
