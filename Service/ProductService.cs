using Domain.Entity;
using Domain.Response;
using Repositories;

namespace Services
{
    public class ProductService
    {
        TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public PagedList<Product> ListProducts(int page)
        {
            int paged = (page - 1) * 10;
            var products = _ctx.Products.Skip(paged).Take(10).ToList();

            var hasNext = _ctx.Products.Count() > paged * 10 + 10;

            return new PagedList<Product>
            {
                HasNext = hasNext,
                TotalCount = _ctx.Products.Count(),
                Items = products
            };
        }

    }
}
