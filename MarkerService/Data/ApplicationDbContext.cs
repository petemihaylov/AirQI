using Microsoft.EntityFrameworkCore;
using MarkerService.Domain;

namespace MarkerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

        public DbSet<Marker> Markers { get; set; }
        public DbSet<SlaMarker> SlaMarkers {get; set;}

        public DbSet<Notification> Notifications { get; set; }
    }
}