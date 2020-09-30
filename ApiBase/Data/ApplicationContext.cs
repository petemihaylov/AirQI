using System.Linq;
using ApiBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
***REMOVED***
    public class ApplicationContext : DbContext
    ***REMOVED***
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)***REMOVED******REMOVED***

        
        public DbSet<User> Users ***REMOVED*** get; set;***REMOVED***
        public DbSet<Role> Roles ***REMOVED*** get; set;***REMOVED*** 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        ***REMOVED***
            modelBuilder.Entity<User>()
            .HasOne(u => u.UserRole)
            .WithOne(r => r.User)
            .HasForeignKey<User>(u => u.RoleId);

       ***REMOVED***
   ***REMOVED***
***REMOVED***