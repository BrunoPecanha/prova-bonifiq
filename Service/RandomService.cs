using Domain.Entity;
using Domain.Repository;
using Domain.Services;

namespace Services
{
    public class RandomService : IRandomService
    {
        private readonly IRandomRepository _randomRepository;
       
        public RandomService(IRandomRepository randomRepository)
        {
            _randomRepository = randomRepository;
        }
        public async Task<int> GetRandomAsync()
        {
            int number;
            var random = new Random();

            do
            {
                number = random.Next(100);
            }
            while (await _randomRepository.NumberAlreadyExists(number));

            var newNumber = new RandomNumber { Number = number };

            await _randomRepository.AddAsync(newNumber);
            await _randomRepository.SaveChangesAsync();

            return number;
        }
    }
}