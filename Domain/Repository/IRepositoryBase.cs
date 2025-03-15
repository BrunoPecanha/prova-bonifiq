using Domain.Response;

namespace Domain.Repository {
    public interface IRepositoryBase<T> where T : class {
        Task AddAsync(T obj);    
        void Update(T obj);
        void Remove(T obj);
        Task DisposeAsync();
        Task SaveChangesAsync();
        Task<PagedList<T>> ListAsync(IQueryable<T> query, int page, int pageSize);
    }
}