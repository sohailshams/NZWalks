using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTOs;
using NZWalks.API.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data from DB - model
            var regions = await regionRepository.GetAllAsync();
            
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

            // return DTOs
            return Ok(regionDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Data from DB - model

            var region = await regionRepository.GetRegionAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            // Map model to DTOs
            var regionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            // return DTO
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddReagion([FromBody] AddRegionDto addRegion)
        {
            // Convert DTO to model
            var regionModel = new Region
            {
                Code = addRegion.Code,
                Name = addRegion.Name,
                RegionImageUrl = addRegion.RegionImageUrl
            };

            // Use model to create region in DB
            await dbContext.Regions.AddAsync(regionModel);
            await dbContext.SaveChangesAsync();

            // Map model to DTOs
            var regionDto = new RegionDTO
            {
                Id = regionModel.Id,
                Code = regionModel.Code,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updatedRegion)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) 
            { 
                return NotFound(); 
            }

            // Map DTO to model
            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.RegionImageUrl = updatedRegion.RegionImageUrl;
      

            // Save the changes in DB
            await dbContext.SaveChangesAsync();

            // Convert model to DTO
            var regionDto = new RegionDTO
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                RegionImageUrl = existingRegion.RegionImageUrl
            };

           return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return NotFound();
            }

            // Delete Region 
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            // Convert model to DTO and return deleted region
            var regionDto = new RegionDTO
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                RegionImageUrl = existingRegion.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
