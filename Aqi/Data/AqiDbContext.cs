using Microsoft.EntityFrameworkCore;
using Aqi.Models;

namespace Aqi.Data
***REMOVED***
    public class AqiDbContext : DbContext
    ***REMOVED***
        
        public AqiDbContext(DbContextOptions<AqiDbContext> options) : base(options)
        ***REMOVED***
            
       ***REMOVED***

        public DbSet<Station> Stations ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***