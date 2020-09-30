using System.Linq;
using ApiBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt){ }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.UserRole)
            .WithOne(r => r.User)
            .HasForeignKey<User>(u => u.RoleId);

        }
    }
}