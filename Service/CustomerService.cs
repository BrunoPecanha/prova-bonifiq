using AutoMapper;
using Domain.Repository;
using Domain.Request;
using Domain.Response;
using Domain.Services;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<PagedList<CustomerResponse>> ListCustomersAsync(int page, int pageSize = 10)
        {
            var costumerList = await _customerRepository.GetPagedProductsAsync(page, pageSize);
            return _mapper.Map<PagedList<CustomerResponse>>(costumerList);
        }

        public async Task<bool> CanPurchase(CanPurchaseRequest request)
        {
            if (request.CustomerId <= 0) throw new ArgumentOutOfRangeException(nameof(request.CustomerId));
            if (request.PurchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(request.PurchaseValue));
            
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer == null)
                throw new InvalidOperationException($"Customer Id {request.CustomerId} does not exist");

            return customer.IsPurchaseAllowed(request.PurchaseValue);
        }       
    }
}