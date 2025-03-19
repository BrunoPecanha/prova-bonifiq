using Domain.Response;

namespace Domain.Services
{
    public interface IProductService
    {
        Task<PagedList<ProductResponse>> ListProductsAsync(int page, int pageSize = 10);
    }
}
