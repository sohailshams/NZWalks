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
