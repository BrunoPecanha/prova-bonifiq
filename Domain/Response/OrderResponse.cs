namespace Domain.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Value { get; set; }        
        public string OrderDate { get; set; }
    }
}
