using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Authentication  
***REMOVED***  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  
    ***REMOVED***  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        ***REMOVED***  

       ***REMOVED***  

        protected override void OnModelCreating(ModelBuilder builder)  
        ***REMOVED***  
            base.OnModelCreating(builder);  
       ***REMOVED***  
   ***REMOVED***  
***REMOVED*** 