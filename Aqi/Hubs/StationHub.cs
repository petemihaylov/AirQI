using System.Threading.Tasks;
using Aqi.Hubs.Clients;
using Aqi.Models.Data;
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
