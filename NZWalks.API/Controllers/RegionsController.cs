using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data from DB - model
            var regions = dbContext.Regions.ToList();
            
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
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get Data from DB - model

            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

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
        public IActionResult AddReagion([FromBody] AddRegionDto addRegion)
        {
            // Convert DTO to model
            var regionModel = new Region
            {
                Code = addRegion.Code,
                Name = addRegion.Name,
                RegionImageUrl = addRegion.RegionImageUrl
            };

            // Use model to create region in DB
            dbContext.Regions.Add(regionModel);
            dbContext.SaveChanges();

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
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updatedRegion)
        {
            var existingRegion = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (existingRegion == null) 
            { 
                return NotFound(); 
            }

            // Map DTO to model
            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.RegionImageUrl = updatedRegion.RegionImageUrl;
      

            // Save the changes in DB
            dbContext.SaveChanges();
            var regionDto = new Region
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                RegionImageUrl = existingRegion.RegionImageUrl
            };

            // Convert model to DTO

            return Ok(regionDto);
        }
    }
}
