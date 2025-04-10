using Microsoft.EntityFrameworkCore;
using NGNWalks.API.Data;
using NGNWalks.API.Models.Domain;

namespace NGNWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        public Task<Walk> CreateAsync(Walk walk)
        {
            throw new NotImplementedException();
        }

        public Task<List<Walk>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Walk?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }