using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTOs;
using NZWalks.API.Helpers;
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

        public async Task<List<Region>> GetAllAsync(QueryObjects query)
        {
            var regions = dbContext.Regions.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchString))
            {
                regions = regions.Where(r => r.Name.Contains(query.searchString) || r.Code.Contains(query.searchString));
            }
            return await regions.ToListAsync();
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

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) return null;

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
