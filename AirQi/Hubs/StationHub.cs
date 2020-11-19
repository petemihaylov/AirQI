using System.Threading.Tasks;
using Aqi.Hubs.Clients;
using Aqi.Models.Data;
using Microsoft.AspNetCore.SignalR;

namespace AssetNXT.Hubs
***REMOVED***
    public class RuuviStationHub : Hub<IStationClient>
    ***REMOVED***
        public async Task SendRuuviStation(Station station)
        ***REMOVED***
            await Clients.All.ReceiveStation(station);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
