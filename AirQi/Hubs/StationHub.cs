using System.Threading.Tasks;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class StationHub : Hub
    {
        public Task ReceiveStation(Station value)
        {
            return Clients.All.SendAsync("GetNewStations", value);
        }
    }
}
