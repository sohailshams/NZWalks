using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalkAsync();
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk> AddWalkAsync(Walk walk);
        Task<Walk?> updateWalkAsync(Guid id,  Walk upatedWalkValues);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
