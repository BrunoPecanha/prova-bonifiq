namespace Services.Payments
{
    public class PixPayment : IPaymentStrategy
    {
        public async Task ProcessPayment(decimal paymentValue)
        {           
            await Task.Delay(500);
            Console.WriteLine($"Pagamento de {paymentValue:C} realizado via Pix.");
        }
    }
}
