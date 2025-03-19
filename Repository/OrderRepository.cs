using Domain.Entity;
using Domain.Repository;

namespace Infra
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(TestDbContext ctx)
            : base(ctx)
        {
        }      
    }
}