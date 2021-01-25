using System.Threading.Tasks;
using ApiBase.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Hubs
{
    public class LiveMarkerHub : Hub
    {
        public Task GetNewMarker(Notification value)
        {
            return Clients.All.SendAsync("GetNewMarker", value);
        }
    }
}
