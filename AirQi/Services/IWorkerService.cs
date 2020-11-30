using System.Threading.Tasks;

namespace AirQi.Services
{
    public interface IWorkerService
    {
        Task PullDataAsync();
    }
}