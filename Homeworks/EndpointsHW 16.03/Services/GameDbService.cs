using EndpointsHW_16._03.Data;

namespace EndpointsHW_16._03.Services
{
    public class GameDbService
    {
        private static object locker = new object();
        private GameContext db;
        public GameDbService()
        {
            db = new GameContext();
        }
        public async Task AddGame(GameModel game)
        {
            lock (locker)
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
        }
        public async Task DeleteGame(string name)
        {
            lock (locker)
            {
                db.Games.Remove(db.Games.Where(g=>g.Name == name).FirstOrDefault()!);
                db.SaveChanges();
            }
        }
        public async Task<GameModel> GetGame(int id) => db.Games.Where(g => g.Id == id).FirstOrDefault()!;
        public async Task<GameModel> GetGame(string name) => db.Games.Where(g => g.Name == name).FirstOrDefault()!;
        public async Task<ICollection<GameModel>> GetGames() => db.Games.ToList();
        public async Task<ICollection<GameModel>> GetGamesByFilter(string genre, string author) => db.Games.Where(g=>g.Genre == genre && g.Author == author).ToList();
        public async Task<ICollection<GameModel>> GetGamesByGenre(string genre) => db.Games.Where(g=>g.Genre == genre).ToList();
        public async Task<ICollection<GameModel>> GetGamesByAuthor(string author) => db.Games.Where(g=>g.Author == author).ToList();
    }
}
