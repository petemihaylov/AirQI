using System.Threading.Tasks;
using ApiBase.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Hubs
***REMOVED***
    public class LiveMarkerHub : Hub
    ***REMOVED***
        public Task GetNewMarker(Notification value)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewMarker", value);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
