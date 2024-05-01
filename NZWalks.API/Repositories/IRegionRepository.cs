using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
      Task<List<Region>>  GetAllAsync();
        Task<Region?> GetRegionByIdAsync(Guid id);
        //Task<Region> AddRegionAsync(Region region);
        //Task<Region?> UpdateRegionAsync(Guid id, Region region, Region existingRegion);
        //  Task<Region?> UpdateRegionAsync(Guid id, Region region, Region? existingRegion);
        //  object UpdateRegionAsync(Guid id, Region region, UpdateRegionDto updatedRegion);
    }
}
