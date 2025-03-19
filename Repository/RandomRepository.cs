using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class RandomRepository : RepositoryBase<RandomNumber>, IRandomRepository
    {
        private readonly TestDbContext _ctx;
        public RandomRepository(TestDbContext ctx)
            : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> NumberAlreadyExists(int number)
            => await _ctx.Numbers.AnyAsync(x => x.Number == number);        
    }
}