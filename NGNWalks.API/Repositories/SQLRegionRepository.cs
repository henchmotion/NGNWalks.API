using Microsoft.EntityFrameworkCore;
using NGNWalks.API.Data;
using NGNWalks.API.Models.Domain;

namespace NGNWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NGNWalksDbContext dbContext;

        public SQLRegionRepository(NGNWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            return dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           
            if (existingRegion == null)
            {
                return null;
            } 

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        
        }

        
    }
}
