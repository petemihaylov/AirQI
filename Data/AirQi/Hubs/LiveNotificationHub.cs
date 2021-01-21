using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Models.Data;
using Microsoft.AspNetCore.SignalR;

namespace AirQi.Hubs
***REMOVED***
    public class LiveNotificationHub : Hub
    ***REMOVED***
        public Task GetNewNotificationsAsync(List<Notification> notifications)
        ***REMOVED***
            return Clients.All.SendAsync("GetNewNotificationsAsync", notifications);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
