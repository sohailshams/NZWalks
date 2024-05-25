using NZWalks.API.DTOs;

namespace NZWalks.API.Services
{
    public interface IWalkService
    {
        public Task<WalkDTO> AddWalkAsync(AddWalkDTO addWalk);
    }
}
