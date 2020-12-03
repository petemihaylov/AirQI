using System.Threading.Tasks;
using AirQi.Hubs.Clients;
using AirQi.Models;
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
