using ApiBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
***REMOVED***
    public class ApplicationContext : DbContext
    ***REMOVED***
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt) ***REMOVED******REMOVED***


        public DbSet<User> Users ***REMOVED*** get; set;***REMOVED***
        public DbSet<Notification> Notifications ***REMOVED*** get; set;***REMOVED***
        public DbSet<Marker> Markers ***REMOVED*** get; set;***REMOVED***

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        ***REMOVED***
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
       ***REMOVED***
   ***REMOVED***
***REMOVED***