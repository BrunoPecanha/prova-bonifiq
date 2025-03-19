using Domain.Enum;

namespace Domain.Request
{
    public class PaymentRequest
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public int PaymentValue { get; set; }
        public int CustomerId { get; set; }
    }
}
