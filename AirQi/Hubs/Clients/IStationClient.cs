using System.Threading.Tasks;
using Aqi.Models.Data;

namespace Aqi.Hubs.Clients
{
    public interface IStationClient
    {
        Task ReceiveStation(Station station);
    }
}
