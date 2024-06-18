using AutoMapper;
using NZWalks.API.DTOs;
using NZWalks.API.Helpers;
using NZWalks.API.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionService(
            IRegionRepository regionRepository,
            IMapper mapper
            )
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<List<RegionDTO>> GetAllRegionsAsync(QueryObjects query)
        {
            // Get Data from DB
            var regions = await _regionRepository.GetAllAsync(query);

            // Map model to DTOs
            var regionDtos = _mapper.Map<List<RegionDTO>>(regions);

            return regionDtos;
        }

        public async Task<RegionDTO?> GetRegionByIdAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            // Map model to DTO
            var regionDto = _mapper.Map<RegionDTO>(region);

            return regionDto;
        }


        public async Task<RegionDTO> AddRegionAsync(AddRegionDTO  addRegion)
        {
            // Convert AddRegionDTO to model
            var regionModel = _mapper.Map<Region>(addRegion);

            // Use model to create region in DB
            regionModel = await _regionRepository.AddRegionAsync(regionModel);

            //Map model to DTO
            var regionDto = _mapper.Map<RegionDTO>(regionModel);

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

        public async Task<RegionDTO?> DeleteRegionAsync(Guid id)
        {
            var deltedRegion = await _regionRepository.DeleteRegionAsync(id);

            if (deltedRegion == null) return null;  

            // Convert deleted region model to DTO
            var regionDto = new RegionDTO
            {
                Id = deltedRegion.Id,
                Code = deltedRegion.Code,
                Name = deltedRegion.Name,
                RegionImageUrl = deltedRegion.RegionImageUrl
            };

            return regionDto;
        }

    }
}
