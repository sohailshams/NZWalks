using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
      Task<List<Region>>  GetAllAsync();
    }
}
