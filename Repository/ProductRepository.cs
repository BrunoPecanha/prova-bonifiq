using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly TestDbContext _ctx;
        public ProductRepository(TestDbContext ctx)
            : base(ctx)
        {
            this._ctx = ctx;
        }

        public async Task<PagedList<Product>> GetPagedProductsAsync(int page, int pageSize)
        {
            var totalCount = await _ctx.Products.CountAsync();

            var items = await _ctx.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();

            var hasNext = (page * pageSize) < totalCount;

            return new PagedList<Product>(items, totalCount, hasNext);
        }       
    }
}