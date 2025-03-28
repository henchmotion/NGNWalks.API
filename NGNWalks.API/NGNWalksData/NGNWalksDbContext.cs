using Microsoft.EntityFrameworkCore;
using NGNWalks.API.Models.Domain;

namespace NGNWalks.API.Data
{
    public class NGNWalksDbContext:DbContext 
    {
        public NGNWalksDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
