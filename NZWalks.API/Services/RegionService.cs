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

        public async Task<RegionDTO?> UpdateRegionAsync(Guid id, UpdateRegionDTO updateRegion)
        {

            // Convert DTO to model
            var regionModelUpdatedValues = new Region
            {
                Code = updateRegion.Code,
                Name = updateRegion.Name,
                RegionImageUrl = updateRegion.RegionImageUrl
            };

            var updatedRegionModel = await _regionRepository.UpdateRegionAsync(id, regionModelUpdatedValues);
            if (updatedRegionModel == null) return null;

            // Convert updated model to DTO
            var updatedRegionDto = new RegionDTO
            {
                Id = updatedRegionModel.Id,
                Code = updatedRegionModel.Code,
                Name = updatedRegionModel.Name,
                RegionImageUrl = updatedRegionModel.RegionImageUrl
            };


            return updatedRegionDto;

        }

    }
}
