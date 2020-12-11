using System.Threading.Tasks;
using ApiBase.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Hubs
{
    public class LiveNotificationHub : Hub
    {
        public Task GetNewNotification(Notification value)
        {
            return Clients.All.SendAsync("GetNewNotification", value);
        }
    }
}
