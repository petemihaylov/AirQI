using System.Threading.Tasks;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class StationHub : Hub
    ***REMOVED***
        public Task ReceiveStation(Station value)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewStations", value);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
