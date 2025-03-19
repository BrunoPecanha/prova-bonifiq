namespace Domain.Request
{
    public class CanPurchaseRequest
    {
        public int CustomerId { get; set; }
        public decimal PurchaseValue { get; set; }
    }
}
