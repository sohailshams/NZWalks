using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTOs;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;
        public RegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            var regions = await dbContext.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

       

        public async Task<Region?> UpdateRegionAsync(Guid id, Region regionModelUpdatedValues)
        {
            var existingRegion = await dbContext.Regions.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) return null;

            existingRegion.Code = regionModelUpdatedValues.Code;
            existingRegion.Name = regionModelUpdatedValues.Name;
            existingRegion.RegionImageUrl = regionModelUpdatedValues.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
