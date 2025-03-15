using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Services
{
    public class RandomService
    {
        TestDbContext _ctx;
        public RandomService()
        {
            var contextOptions = new DbContextOptionsBuilder<TestDbContext>().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Teste;Trusted_Connection=True;").Options;

            _ctx = new TestDbContext(contextOptions);
        }
        public async Task<int> GetRandom()
        {
            int number;
            var random = new Random();

            do
            {
                number = random.Next(100);
            }
            while (await _ctx.Numbers.AnyAsync(n => n.Number == number));

            var newNumber = new RandomNumber { Number = number };

            _ctx.Numbers.Add(newNumber);
            await _ctx.SaveChangesAsync();

            return number;
        }
    }
}