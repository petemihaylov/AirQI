using System.Threading.Tasks;
using ApiBase.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Hubs
***REMOVED***
    public class LiveNotificationHub : Hub
    ***REMOVED***
        public Task GetNewNotification(Notification value)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewNotification", value);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
