using NGNWalks.API.Models.Domain;

namespace NGNWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
    }
}
