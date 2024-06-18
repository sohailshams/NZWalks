using NZWalks.API.DTOs;
using NZWalks.API.Helpers;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
      Task<List<Region>>  GetAllAsync(QueryObjects query);
        Task<Region?> GetRegionByIdAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region regionModelUpdatedValues);
        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
