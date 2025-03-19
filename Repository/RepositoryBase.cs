using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _ctx;

        public RepositoryBase(DbContext context)
        {
            _ctx = context;
        }

        public async Task AddAsync(T obj)
            =>  await _ctx.Set<T>().AddAsync(obj);

        public async Task<T> GetByIdAsync(int id)
            => await _ctx.Set<T>().FindAsync(id);        

        public async Task DisposeAsync()
            => await _ctx.DisposeAsync();        

        public void Remove(T obj)
            => _ctx.Remove(obj);

        public async Task SaveChangesAsync()
            => await _ctx.SaveChangesAsync();

        public async Task Update(T obj)
            => await Update(obj);
    }
}
