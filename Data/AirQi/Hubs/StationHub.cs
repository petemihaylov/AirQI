using System.Threading.Tasks;
using AirQi.Hubs;
using AirQi.Models.Core;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class StationHub : Hub, IStationClient
    ***REMOVED***
        public Task ReceiveStation(Station station)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewStations", station);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
