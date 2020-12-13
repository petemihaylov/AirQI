using System;
using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
{
    public class StationHub<TDocument> : Hub, IStationClient<TDocument>
    {
        public Task ReceiveStationAsync(TDocument document)
        {
            return Clients.All.SendAsync("GetNewStations", document);
        }
    }
}
