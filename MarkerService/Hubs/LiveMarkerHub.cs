using System.Threading.Tasks;
using MarkerService.Domain;
using Microsoft.AspNetCore.SignalR;

namespace MarkerService.Hubs
{
    public class LiveMarkerHub : Hub
    {
        public Task GetNewMarker(Notification value)
        {
            return Clients.All.SendAsync("GetNewMarker", value);
        }
    }
}
