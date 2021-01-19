using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class LiveStationHub : Hub
    ***REMOVED***
        public Task GetNewStationsAsync(List<Station> stations)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewStationsAsync", stations);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
