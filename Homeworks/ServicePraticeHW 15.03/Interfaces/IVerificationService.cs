namespace ServicePratice.Interfaces
{
    public interface IVerificationService<T> where T : class
    {
        Task<bool> CompareEntities(T currentEntity, T secondaryEntity);
    }
}
