
using System;
using System.Threading.Tasks;
using ApiBase.Data;
using ApiBase.Hubs;
using ApiBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarkersController : ControllerBase
    {

        private readonly IEFRepository _repository;
        private readonly IHubContext<LiveMarkerHub> _hubContext;

        private readonly IHubContext<LiveNotificationHub> _hubNotificationContext;

        public MarkersController(IEFRepository repository, IHubContext<LiveMarkerHub> hubContext, IHubContext<LiveNotificationHub> hubNotificationContext)
        {
            this._repository = repository;
            this._hubContext = hubContext;
            this._hubNotificationContext = hubNotificationContext;
        }

        // GET: api/markers
        [HttpGet]
        public async Task<IActionResult> GetMarkers()
        {
            var markers = await _repository.GetAllAsync<Marker>();

            return Ok(markers);
        }

        //GET api/markers/{id}
        [HttpGet("{id}", Name = "GetMarkerById")]
        public async Task<ActionResult<Marker>> GetMarkerById(int id)
        {
            var markerItem = await _repository.GetByIdAsync<Marker>(id);
            if (markerItem != null)
            {
                return Ok(markerItem);
            }
            return NotFound();
        }

        // POST: api/markers
        [HttpPost]
        public async Task<IActionResult> AddMarker(Marker message)
        {
            var markerItem = await _repository.AddAsync(message);

            // SignalR event
            await _hubContext.Clients.All.SendAsync("GetNewMarker", markerItem);

            var notificationItem = new Notification("Warning! ", "New Marker has been created!", "Warning", DateTime.Now);
            await _hubNotificationContext.Clients.All.SendAsync("GetNewNotification", notificationItem);

            return Ok();
        }

        // Delete: api/markers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var markerItem = _repository.GetByIdAsync<Marker>(id).Result;
            if (markerItem == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Marker>(markerItem);
            return NoContent();

        }
    }
}