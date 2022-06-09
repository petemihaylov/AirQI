using System.Threading.Tasks;
using MarkerService.Domain;
using Microsoft.AspNetCore.SignalR;

namespace MarkerService.Hubs
{
    public class LiveNotificationHub : Hub
    {
        public Task GetNewNotification(Notification value)
        {
            return Clients.All.SendAsync("GetNewNotification", value);
        }
    }
}
