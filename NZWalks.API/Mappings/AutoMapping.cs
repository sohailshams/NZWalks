using AutoMapper;
using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Mappings
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionDTO, Region>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<AddWalkDTO, Walk>().ReverseMap();
        }
    }
}
