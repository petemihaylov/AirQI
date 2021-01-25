using System.Linq;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt){ }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);

        }
    }
}