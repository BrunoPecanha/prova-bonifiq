namespace Domain.Entity
{
	public class Product : EntityBase
    {
		public string Name { get; private set; }

        private Product()
        {
        }

        public Product(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }   
}
