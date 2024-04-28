using NZWalks.API.Models;

namespace NZWalks.API.Services
{
    public interface IRegionService
    {
        public Task<List<Region>> GetAllAsync();
        public Task<Region> GetRegionAsync(Guid id);
        public Task<Region> AddReagion(Region region);
    }
}
