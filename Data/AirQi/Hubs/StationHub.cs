using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class StationHub<TDocument> : Hub, IStationClient<TDocument>
    ***REMOVED***
        public Task ReceiveStationAsync(List<TDocument> documents)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewStations", documents);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
