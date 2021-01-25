using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AirQi.Hubs
{
    public class LiveStationHub : Hub
    {
        public Task GetNewStationsAsync(List<Station> stations)
        {
            return Clients.All.SendAsync("GetNewStationsAsync", stations);
        }
    }
}
