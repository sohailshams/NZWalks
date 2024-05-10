using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Services
{
    public interface IRegionService
    {
        public Task<List<RegionDTO>> GetAllRegionsAsync();
        public Task<RegionDTO?> GetRegionByIdAsync(Guid id);
        public Task<RegionDTO> AddRegionAsync(AddRegionDTO addRegion);

        public Task<RegionDTO?> UpdateRegionAsync(Guid id, UpdateRegionDTO updatedRegion);
    }
}
