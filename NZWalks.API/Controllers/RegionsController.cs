using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTOs;
using NZWalks.API.Models;
using NZWalks.API.Repositories;
using NZWalks.API.Services;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;
        public RegionsController(
            IRegionService regionService
            )
        {
            _regionService = regionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegionsAsync()
        {
            // Get Data from DB
            var regions = await _regionService.GetAllRegionsAsync();
            
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            // Get Data from DB - model

            var region = await _regionService.GetRegionByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            // return DTO
            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> AddReagion([FromBody] AddRegionDTO addRegion)
        {

            // Use model to create region in DB
            var region = await _regionService.AddRegionAsync(addRegion);

            // Map model to DTOs
            //var regionDto = new RegionDTO
            //{
            //    Id = regionModel.Id,
            //    Code = regionModel.Code,
            //    Name = regionModel.Name,
            //    RegionImageUrl = regionModel.RegionImageUrl
            //};
            //if (region == null) 
            //{
            //    return StatusCode(500);
            //}

            //return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            return Ok(region);
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updatedRegion)
        //{
        //    var existingRegion = regionRepository.UpdateRegionAsync(id, updatedRegion);
        //    if (existingRegion == null) 
        //    { 
        //        return NotFound(); 
        //    }  

        //    // Save the changes in DB
        //    await dbContext.SaveChangesAsync();

        //    // Convert model to DTO
        //    var regionDto = new RegionDTO
        //    {
        //        Id = existingRegion.Id,
        //        Code = existingRegion.Code,
        //        Name = existingRegion.Name,
        //        RegionImageUrl = existingRegion.RegionImageUrl
        //    };

        //   return Ok(regionDto);
        //}

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        //{
        //    var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        //    if (existingRegion == null)
        //    {
        //        return NotFound();
        //    }

        //    // Delete Region 
        //    dbContext.Regions.Remove(existingRegion);
        //    await dbContext.SaveChangesAsync();

        //    // Convert model to DTO and return deleted region
        //    var regionDto = new RegionDTO
        //    {
        //        Id = existingRegion.Id,
        //        Code = existingRegion.Code,
        //        Name = existingRegion.Name,
        //        RegionImageUrl = existingRegion.RegionImageUrl
        //    };

        //    return Ok(regionDto);
        //}
    }
}
