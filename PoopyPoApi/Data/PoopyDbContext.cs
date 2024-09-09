using Microsoft.EntityFrameworkCore;
using PoopyPoApi.Models.Domain;

namespace PoopyPoApi.Data
{
    public class PoopyDbContext : DbContext
    {
        public PoopyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<PoopLocations> PoopLocations { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
