using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQi.Services.Configurations
{
    public interface IServiceConfiguration<TConfiguration>
    {
        Task<List<TConfiguration>> IsBreachedCollection();

        void SaveConfiguration(object obj);
    }
}