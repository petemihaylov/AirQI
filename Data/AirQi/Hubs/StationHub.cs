using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class StationHub<TDocument> : Hub, IStationClient<TDocument>
    {
        public Task ReceiveStationAsync(List<TDocument> documents)
        {
            return Clients.All.SendAsync("GetNewStations", documents);
        }
    }
}
