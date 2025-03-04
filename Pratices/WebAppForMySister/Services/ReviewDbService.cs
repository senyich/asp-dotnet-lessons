
using WebAppForMySister.Data;
using WebAppForMySister.Data.Models;

namespace WebAppForMySister.Services
{
    public class ReviewDbService : IDbService<ReviewModel>
    {
        private Context db;
        private static object locker = new();
        public ReviewDbService()
        {
            db = new Context();
        }
        public async Task<ICollection<ReviewModel>> GetAllEntities() => db.Reviews.ToList();
        public async Task<ReviewModel> GetEntityById(int id) => db.Reviews.Where(r => r.Id == id).FirstOrDefault();
        public async Task AddEntity(ReviewModel entity)
        {
            lock(locker)
            {
                db.Reviews.Add(entity);
                db.SaveChanges();
            }
        }
        public async Task RemoveEntity(int id)
        {
            lock (locker)
            {
                var entity = db.Reviews.Where(r => r.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    db.Reviews.Add(entity);
                    db.SaveChanges();
                }
                else
                    throw new NotImplementedException("Такой сущности нет");
            }
        }
        public async Task RemoveEntity(ReviewModel entity)
        {
            lock(locker)
            {
                if (entity != null)
                {
                    db.Reviews.Add(entity);
                    db.SaveChanges();
                }
                else
                    throw new NotImplementedException("Такой сущности нет");
            }
        }
    }
}
