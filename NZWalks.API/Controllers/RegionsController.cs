﻿using Microsoft.AspNetCore.Mvc;
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

            var region = await _regionService.AddRegionAsync(addRegion);

            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO updatedRegion)
        {
            var region = await _regionService.UpdateRegionAsync(id, updatedRegion);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await _regionService.DeleteRegionAsync(id);
            if (region == null) 
            { 
                return NotFound(); 
            }

            return Ok(region);
        }
    }
}
