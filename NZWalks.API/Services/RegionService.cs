using NZWalks.API.DTOs;
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

        public async Task<List<RegionDTO>> GetAllRegionsAsync()
        {
            // Get Data from DB - model
            var regions = await _regionRepository.GetAllAsync();

            // Map model to DTOs
            var regionDtos = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDtos.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return regionDtos;
        }

        public async Task<RegionDTO?> GetRegionByIdAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            // Map model to DTOs
            var regionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return regionDto;
        }


        public async Task<RegionDTO> AddRegionAsync(AddRegionDTO addRegion)
        {
            //if (addRegion is null) return null;

            // Convert DTO to model
            var regionModel = new Region
            {
                Code = addRegion.Code,
                Name = addRegion.Name,
                RegionImageUrl = addRegion.RegionImageUrl
            };

            // Use model to create region in DB
            regionModel = await _regionRepository.AddRegionAsync(regionModel);

            //Map model to DTOs
            var regionDto = new RegionDTO
            {
                Id = regionModel.Id,
                Code = regionModel.Code,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl
            };

            return regionDto;
        }

        //public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        //{
        //    var existingRegion = _regionRepository.GetRegionByIdAsync(id);
        //    if (existingRegion == null) return null;


        //    return await _regionRepository.UpdateRegionAsync(Guid id, Region region, UpdateRegionDto existingRegion);
        //}

    }
}
