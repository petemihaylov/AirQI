using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Models.Data;
using Microsoft.AspNetCore.SignalR;

namespace AirQi.Hubs
{
    public class LiveNotificationHub : Hub
    {
        public Task GetNewNotificationsAsync(List<Notification> notifications)
        {
            return Clients.All.SendAsync("GetNewNotificationsAsync", notifications);
        }
    }
}
