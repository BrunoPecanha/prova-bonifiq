using Domain.Entity;

namespace Domain.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<PagedList<Customer>> GetPagedProductsAsync(int page, int pageSize);
    }
}
