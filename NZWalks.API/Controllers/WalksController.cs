using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTOs;
using NZWalks.API.Services;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkService _walkService;

        public WalksController(
            IWalkService walkService
            )
        {
            _walkService = walkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            // Get Data from DB
            var walks = await _walkService.GetAllWalksAsync();

            return Ok(walks);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkDTO addWalk)
        {
            var walk = await _walkService.AddWalkAsync(addWalk);
              
            return Ok(walk);

        }
    }
}
