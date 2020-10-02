using Microsoft.EntityFrameworkCore;
using Aqi.Models;

namespace Aqi.Data
{
    public class AqiDbContext : DbContext
    {
        
        public AqiDbContext(DbContextOptions<AqiDbContext> options) : base(options)
        {

        }

        public DbSet<Station> Stations { get; set; }
    }
}