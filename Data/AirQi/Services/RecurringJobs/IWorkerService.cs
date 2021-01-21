using System.Threading.Tasks;

namespace AirQi.Services.RecurringJobs
{
    public interface IWorkerService
    {
        Task PullDataAsync();
    }
}