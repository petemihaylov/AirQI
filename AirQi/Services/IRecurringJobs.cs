using System.Threading.Tasks;

namespace AirQi.Services
{
    public interface IRecurringJobs
    {
        Task PullOpenAqiDataAsync();
    }
}