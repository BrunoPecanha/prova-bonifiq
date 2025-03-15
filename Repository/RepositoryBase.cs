using Domain.Repository;
using Domain.Response;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task AddAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<T>> ListAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).AsNoTracking().Take(pageSize).ToListAsync();

            return new PagedList<T>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
