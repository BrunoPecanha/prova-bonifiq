using AutoMapper;
using Domain.Repository;
using Domain.Response;
using Domain.Services;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<PagedList<ProductResponse>> ListProductsAsync(int page, int pageSize = 10)
        {
            var productList = await _productRepository.GetPagedProductsAsync(page, pageSize);
            return _mapper.Map<PagedList<ProductResponse>>(productList);
        }
    }
}