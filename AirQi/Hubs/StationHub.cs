using System.Threading.Tasks;
using AirQi.Hubs.Clients;
using AirQi.Models;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class RuuviStationHub : Hub<IStationClient>
    {
        public async Task SendRuuviStation(Station station)
        {
            await Clients.All.ReceiveStation(station);
        }
    }
}
