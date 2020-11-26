using System.Threading.Tasks;

namespace AirQi
{
    public interface IRecurringJobs
    {
        Task PullOpenAqiDataAsync();
    }
}