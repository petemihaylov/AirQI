using System.Linq;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Data
***REMOVED***
    public class ApplicationContext : DbContext
    ***REMOVED***
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)***REMOVED******REMOVED***

        public DbSet<User> Users ***REMOVED*** get; set;***REMOVED***


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        ***REMOVED***
            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);

       ***REMOVED***
   ***REMOVED***
***REMOVED***