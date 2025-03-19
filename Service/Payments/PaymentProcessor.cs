using Domain.Enum;
using Services.Payments;

public class PaymentProcessor
{
    private readonly Dictionary<PaymentMethodEnum, IPaymentStrategy> _paymentList;

    public PaymentProcessor(IEnumerable<IPaymentStrategy> paymentList)
    {
        _paymentList = paymentList.ToDictionary(s =>
             Enum.Parse<PaymentMethodEnum>(s.GetType().Name.Replace("Payment", ""), true));
    }

    public async Task ProcessPayment(PaymentMethodEnum paymentMethod, decimal paymentValue)
    {
        if (!_paymentList.TryGetValue(paymentMethod, out var strategy))
            throw new ArgumentException("Payment method not valid.");

        await strategy.ProcessPayment(paymentValue);
    }   
}