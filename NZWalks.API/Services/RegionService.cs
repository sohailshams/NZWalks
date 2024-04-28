using NZWalks.API.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(
            IRegionRepository regionRepository
            )
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await _regionRepository.GetRegionByIdAsync(id);
        }

        public async Task<Region> AddReagion(Region region)
        {
            return await _regionRepository.AddRegionAsync(region);
        }
    }
}
