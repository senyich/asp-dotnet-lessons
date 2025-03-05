namespace WebAppForMySister.Services
{
    public interface IDbService <T> where T: class
    {
        Task<T> GetEntityById(int id);
        Task<ICollection<T>> GetAllEntities();
        Task AddEntity(T entity);
        Task RemoveEntity(int id);
        Task RemoveEntity(T entity);
    }
}
