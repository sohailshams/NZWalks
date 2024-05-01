using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Services
{
    public interface IRegionService
    {
        public Task<List<RegionDTO>> GetAllRegionsAsync();
        public Task<RegionDTO?> GetRegionByIdAsync(Guid id);
        //public Task<Region> AddReagion(Region region);
        //public Task<Region?> UpdateRegionAsync(Guid id, Region region);
    }
}
