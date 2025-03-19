namespace Services.Payments
{
    public interface IPaymentStrategy
    {
        Task ProcessPayment(decimal paymentValue);
    }
}
