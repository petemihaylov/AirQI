using System.Threading.Tasks;
using AirQi.Models.Data;

namespace AirQi.Hubs.Clients
{
    public interface IStationClient
    {
        Task ReceiveStation(Station station);
    }
}
