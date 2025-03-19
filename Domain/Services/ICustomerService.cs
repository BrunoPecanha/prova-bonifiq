using Domain.Request;
using Domain.Response;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Task<PagedList<CustomerResponse>> ListCustomersAsync(int page, int pageSize = 10);
        Task<bool> CanPurchase(CanPurchaseRequest request);
    }
}
