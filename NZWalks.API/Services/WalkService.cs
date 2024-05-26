using AutoMapper;
using NZWalks.API.DTOs;
using NZWalks.API.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Services
{
    public class WalkService : IWalkService
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkService(
            IWalkRepository walkRepository,
            IMapper mapper
            )
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }
        public async Task<List<WalkDTO>> GetAllWalksAsync()
        {
            var walks = await _walkRepository.GetAllWalkAsync();

            // Map walk model to DTO
            var walksDTOs = _mapper.Map<List<WalkDTO>>( walks );
           
            return walksDTOs;
        }
        public async Task<WalkDTO?> GetWalkByIdAsync(Guid id)
        {
            var walk = await _walkRepository.GetWalkByIdAsync(id);

            // Map model to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walk);

            return walkDTO;
        }
        public async Task<WalkDTO> AddWalkAsync(AddWalkDTO addWalk)
        {
            // Convert AddWalkDTO to model
            var walkModel = _mapper.Map<Walk>(addWalk);

            // Use model to create walk in DB
            walkModel = await _walkRepository.AddWalkAsync(walkModel);

            //Map model to DTO
            var walkDto = _mapper.Map<WalkDTO>(walkModel);

            return walkDto;
        }

    }
}
