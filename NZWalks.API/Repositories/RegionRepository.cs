using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
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

        public NZWalksDbContext DbContext { get; }

        public async Task<List<Region>> GetAllAsync()
        {
            var regions = await dbContext.Regions.ToListAsync();
            return regions;
        }
    }
}
