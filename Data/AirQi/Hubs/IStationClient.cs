using System.Threading.Tasks;
using AirQi.Models.Core;

namespace AirQi.Hubs
{
    public interface IStationClient
    {
        Task ReceiveStation(Station value);
    }
}
