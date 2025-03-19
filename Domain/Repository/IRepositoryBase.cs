using Domain.Response;

namespace Domain.Repository {
    public interface IRepositoryBase<T> where T : class {
        Task AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task Update(T obj);
        void Remove(T obj);
        Task DisposeAsync();
        Task SaveChangesAsync();
    }
}