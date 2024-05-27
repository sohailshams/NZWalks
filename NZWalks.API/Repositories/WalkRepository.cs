using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            var walks = await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            return walks;
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            var walk = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            return walk;
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
