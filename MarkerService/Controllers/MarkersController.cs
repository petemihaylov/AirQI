
using System;
using System.Collections.Generic;
using System.Linq;
using MarkerService.Data.Interfaces;
using MarkerService.DataTransfer;
using MarkerService.Services;
using MarkerService.Domain;
using MarkerService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarkersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IHubContext<LiveMarkerHub> _hubContext;
        private readonly IHubContext<LiveNotificationHub> _hubNotificationContext;

        public MarkersController(IUnitOfWork uow,  IHubContext<LiveMarkerHub> hubContext, IHubContext<LiveNotificationHub> hubNotificationContext)
        {
            this._uow = uow;
            this._hubContext = hubContext;
            this._hubNotificationContext = hubNotificationContext;
        }

        // GET: api/markers
        [HttpGet]
        public ActionResult<IEnumerable<Marker>> GetMarkers()
        {
            return Ok(_uow.Markers.GetAllMarkers());
        }

        // GET api/markers/{id}
        [HttpGet("{id}", Name = "GetMarkerById")]
        public ActionResult<Marker> GetMarkerById(int id)
        {
            var markerItem =  _uow.Markers.GetById(id);
            if (markerItem != null)
            {
                return Ok(markerItem);
            }
            return NotFound();
        }

        // POST: api/markers
        [HttpPost]
        public ActionResult<Marker> AddMarker(Marker marker)
        {
            var list = _uow.SlaMarkers.GetAll().ToList();
            var polygon = PolygonCheckerService.IsInPolygon(list, marker.latitude, marker.longitude);
            if (polygon == true)
            {
                var signalNotification = new NotificationDto
                {
                    Title = "Too many markers!",
                    Description = "You can not create a marker here",
                    Type = "Notify",
                    CreatedAt = DateTime.UtcNow.ToString()
                };
                _hubNotificationContext.Clients.All.SendAsync("GetNewNotification", signalNotification);

                return Conflict();

            }

            var markerItem = _uow.Markers.AddMarker(marker);
            _uow.Complete();

            // SignalR event
            _hubContext.Clients.All.SendAsync("GetNewMarker", markerItem);

            return Ok(markerItem);
        }

        // DELETE: api/markers/{id}
        [HttpDelete("{id}")]
        public ActionResult<Marker> Delete(int id)
        {
            var markerItem = _uow.Markers.GetById(id);
            if (markerItem == null)
            {
                return NotFound();
            }

            _uow.Markers.Remove(markerItem);
            _uow.Complete();
            return NoContent();

        }
    }
}