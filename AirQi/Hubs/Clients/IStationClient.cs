using System.Threading.Tasks;
using AirQi.Models;

namespace AirQi.Hubs.Clients
{
    public interface IStationClient
    {
        Task ReceiveStation(Station station);
    }
}
