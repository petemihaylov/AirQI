using System;
using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class StationHub<TDocument> : Hub, IStationClient<TDocument>
    ***REMOVED***
        public Task ReceiveStationAsync(TDocument document)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewStations", document);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
