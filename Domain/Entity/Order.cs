namespace Domain.Entity
{
    public class Order : EntityBase
    {
        public decimal Value { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime OrderDate { get; private set; }

        private Order()
        {
        }

        public Order(decimal value, Customer customer)
        {
            Value = value;
            CustomerId = customer.Id;
            Customer = customer;
            OrderDate = DateTime.UtcNow;
        }
    }
}
