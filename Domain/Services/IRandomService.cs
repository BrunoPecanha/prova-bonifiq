using Domain.Response;

namespace Domain.Services
{
    public interface IRandomService
    {
        Task<int> GetRandomAsync();
    }
}
