using Domain.Request;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Controllers
{

	/// <summary>
	/// O Código abaixo faz uma chmada para a regra de negócio que valida se um consumidor pode fazer uma compra.
	/// Crie o teste unitário para esse Service. Se necessário, faça as alterações no código para que seja possível realizar os testes.
	/// Tente criar a maior cobertura possível nos testes.
	/// 
	/// Utilize o framework de testes que desejar. 
	/// Crie o teste na pasta "Tests" da solution
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte4Controller :  ControllerBase
	{
        private readonly ICustomerService _customerService;

        public Parte4Controller(ICustomerService customerService)
        {
            _customerService = customerService;
        }

		[HttpGet("CanPurchase")]
		public async Task<ActionResult<bool>> CanPurchase(CanPurchaseRequest request)
			=> Ok(await _customerService.CanPurchase(request));

    }
}
