
namespace ServicePratice.Interfaces
{
    public interface IDbService<T> where T : class
    {
        Task<T> GetEntityByValue(object value);
        Task<T> GetEntityById(int id);
        Task<ICollection<T>> GetAll();
        Task AddEntity(T entity);
        Task DeleteEntity(T entity);
        Task DeleteEntity(int id);
    }
}
