using NZWalks.API.DTOs;

namespace NZWalks.API.Services
{
    public interface IWalkService
    {
        public Task<List<WalkDTO>> GetAllWalksAsync();
        public Task<WalkDTO> AddWalkAsync(AddWalkDTO addWalk);
        public Task<WalkDTO?> GetWalkByIdAsync(Guid id);
    }
}
