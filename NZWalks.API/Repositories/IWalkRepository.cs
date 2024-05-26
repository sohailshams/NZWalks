using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalkAsync();
        Task<Walk> AddWalkAsync(Walk walk);
    }
}
