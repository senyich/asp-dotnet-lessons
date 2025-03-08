using ServicePratice.Data.Models;
using ServicePratice.Data.WebAppForMySister.Data;

namespace ServicePratice.Services
{
    using Interfaces;

    public class UserDbService : IDbService<User>
    {
        private Context db;
        private object locker;
        public UserDbService()
        {
            locker = new object();
            db = new Context();
        }
        public async Task AddEntity(User entity)
        {
            lock (locker)
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
        }
        public async Task DeleteEntity(User entity)
        {
            lock (locker)
            {
                if (entity != null)
                {
                    db.Users.Remove(entity);
                    db.SaveChanges();
                }
            }
        }
        public async Task DeleteEntity(int id)
        {
            lock (locker)
            {
                db.Users.Remove(db.Users.Where(u => u.Id == id).FirstOrDefault()!);
                db.SaveChanges();
            }
        }
        public async Task<ICollection<User>> GetAll() => db.Users.ToList();
        public async Task<User> GetEntityById(int id) => db.Users.Where(u => u.Id == id).FirstOrDefault()!;
        public async Task<User> GetEntityByValue(object value) => db.Users.Where(u => u.Username == (value as string)).FirstOrDefault()!;
    }
}
