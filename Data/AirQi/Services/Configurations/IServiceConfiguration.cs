using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQi.Services.Configurations
***REMOVED***
    public interface IServiceConfiguration<TConfiguration>
    ***REMOVED***
        Task<List<TConfiguration>> IsBreachedCollection();

        void SaveConfiguration(object obj);
   ***REMOVED***
***REMOVED***