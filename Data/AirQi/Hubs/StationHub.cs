using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class StationHub : Hub, IStationClient
    {
        public Task ReceiveStation(Station station)
        {
            return Clients.All.SendAsync("GetNewStations", station);
        }
    }
}
