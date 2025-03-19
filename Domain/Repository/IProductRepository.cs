using Domain.Entity;

namespace Domain.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<PagedList<Product>> GetPagedProductsAsync(int page, int pageSize);
    }
}
