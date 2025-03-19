using Domain.Entity;

namespace Domain.Repository
{
    public interface IRandomRepository : IRepositoryBase<RandomNumber>
    {
        Task<bool> NumberAlreadyExists(int number);
    }
}
