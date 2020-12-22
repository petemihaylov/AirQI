using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class StationHub : Hub
    {
        public Task GetNewStationsAsync(List<Station> stations)
        {
            return Clients.All.SendAsync("GetNewStationsAsync", stations);
        }
    }
}
