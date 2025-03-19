using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly TestDbContext _ctx;

        public CustomerRepository(TestDbContext ctx) 
            : base(ctx) 
        {
            _ctx = ctx;
        }

        public async Task<PagedList<Customer>> GetPagedProductsAsync(int page, int pageSize)
        {
            var totalCount = await _ctx.Products.CountAsync();

            var items = await _ctx.Customers
                .Skip((page - 1) * pageSize)
                .Include(x => x.Orders)
                .Take(pageSize)
                .ToArrayAsync();

            var hasNext = (page * pageSize) < totalCount;

            return new PagedList<Customer>(items, totalCount, hasNext);
        }
    }
}