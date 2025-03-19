namespace Domain.Entity
{
	public class Customer : EntityBase
    {
		public string Name { get;  private set; }
		public ICollection<Order> Orders { get;  private set; } = new List<Order>();

		private Customer()
		{
		}

		public Customer(int id, string name)
		{
			this.Id = id;
			this.Name = name;	
		}

        public Customer(int id, string name, IList<Order> orders)
        {
            this.Id = id;
            this.Name = name;
			this.Orders = orders;
        }

        public  bool IsPurchaseAllowed(decimal purchaseValue)
        {
            var now = DateTime.UtcNow;

            var lastMonth = now.AddMonths(-1);
            if (this.Orders.Any(o => o.OrderDate >= lastMonth))
                return false;

            if (!this.Orders.Any() && purchaseValue > 100)
                return false;

            if (now.Hour < 8 || now.Hour > 18 || now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
                return false;

            return true;
        }
    }
}
