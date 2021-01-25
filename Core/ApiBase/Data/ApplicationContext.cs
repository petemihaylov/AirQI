using ApiBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt) { }


        public DbSet<User> Users { get; set; }
        public DbSet<SlaMarker> SlaMarkers {get; set;}
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Marker> Markers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}