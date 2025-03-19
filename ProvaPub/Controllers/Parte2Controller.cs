using Domain.Response;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Parte2Controller : ControllerBase
    {
        private readonly ICustomerService custumerService;
        private readonly IProductService productService;

        public Parte2Controller(ICustomerService custotmerService, IProductService productService)
        {
            this.custumerService = custotmerService;
            this.productService = productService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<PagedList<ProductResponse>>> ListProductsAsync(int page, int qt = 10)
            => Ok(await productService.ListProductsAsync(page, qt));

        [HttpGet("customers")]
        public async Task<ActionResult<PagedList<CustomerResponse>>> ListCustomersAsync(int page, int qt = 10)
            => Ok(await custumerService.ListCustomersAsync(page, qt));
    }
}