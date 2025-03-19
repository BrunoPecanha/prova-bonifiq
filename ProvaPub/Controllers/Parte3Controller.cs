using Domain.Request;
using Domain.Response;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Controllers
{
    /// <summary>
    /// Esse teste simula um pagamento de uma compra.
    /// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
    /// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
    /// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
    /// 
    /// Outra parte importante é em relação à data (OrderDate) do objeto Order. Ela deve ser salva no banco como UTC mas deve retornar para o cliente no fuso horário do Brasil. 
    /// Demonstre como você faria isso.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class Parte3Controller : ControllerBase
    {
        private readonly IOrderService _orderService;

        public Parte3Controller(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("orders")]
        public async Task<ActionResult<DefaultApiResponse<OrderResponse>>> PlaceOrder([FromBody] PaymentRequest request)
        {
            try
            {
                var response = await _orderService.PayOrderAsync(request);
                return Ok(response); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new DefaultApiResponse<OrderResponse>(new List<string> { ex.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultApiResponse<OrderResponse>(new List<string> { $"Server internal error - {ex.Message}" }));
            }
        }
    }

}
