using Domain.Request;
using Domain.Response;

namespace Domain.Services
{
    public interface IOrderService
    {
        Task<DefaultApiResponse<OrderResponse>> PayOrderAsync(PaymentRequest request);
    }
}
