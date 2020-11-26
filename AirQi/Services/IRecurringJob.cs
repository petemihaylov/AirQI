using System.Threading.Tasks;

namespace AirQi
{
    public interface IRecurringJob
    {
        void ExecuteWorker();

        Task ExecuteWorkerAsync();
    }
}