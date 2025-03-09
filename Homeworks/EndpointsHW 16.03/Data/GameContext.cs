using Microsoft.EntityFrameworkCore;

namespace EndpointsHW_16._03.Data
{
    public class GameContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=62.113.107.207;Port=5432;DataBase=Games;Username=senya;Password=animenit2002");
        }
    }
}
