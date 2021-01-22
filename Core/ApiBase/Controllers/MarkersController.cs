
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBase.Data;
using ApiBase.DTOs;
using ApiBase.Hubs;
using ApiBase.Models;
using ApiBase.Services;
using ApiBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Controllers
***REMOVED***

    [Route("api/[controller]")]
    [ApiController]
    public class MarkersController : ControllerBase
    ***REMOVED***

        private readonly IEFRepository _repository;
        private readonly IHubContext<LiveMarkerHub> _hubContext;
        private readonly IHubContext<LiveNotificationHub> _hubNotificationContext;
        private readonly ISlaMarkerService _slaMarkerService;

        public MarkersController(IEFRepository repository, IHubContext<LiveMarkerHub> hubContext, IHubContext<LiveNotificationHub> hubNotificationContext, ISlaMarkerService slaService)
        ***REMOVED***
            this._repository = repository;
            this._hubContext = hubContext;
            this._hubNotificationContext = hubNotificationContext;
            this._slaMarkerService = slaService;

       ***REMOVED***

        // GET: api/markers
        [HttpGet]
        public async Task<IActionResult> GetMarkers()
        ***REMOVED***
            var markers = await _repository.GetAllAsync<Marker>();

            return Ok(markers);
       ***REMOVED***

        //GET api/markers/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetMarkerById")]
        public async Task<ActionResult<Marker>> GetMarkerById(int id)
        ***REMOVED***
            var markerItem = await _repository.GetByIdAsync<Marker>(id);
            if (markerItem != null)
            ***REMOVED***
                return Ok(markerItem);
           ***REMOVED***
            return NotFound();
       ***REMOVED***

        // POST: api/markers
        [HttpPost]
        public async Task<IActionResult> AddMarker(Marker marker)
        ***REMOVED***
            

            var list = _slaMarkerService.GetSlaMarkers().ToList();
            var polygon = PolygonCheckerService.IsInPolygon(list, marker.latitude, marker.longitude);
            if (polygon == true)
            ***REMOVED***
                // SignalR event
                var signalNotification = new NotificationDto
                ***REMOVED***
                    Title = "Too many markers!",
                    Description = "You can not create a marker here",
                    Type = "Notify",
                    CreatedAt = DateTime.UtcNow.ToString()
               ***REMOVED***;
                await _hubNotificationContext.Clients.All.SendAsync("GetNewNotification", signalNotification);

                return Conflict();

           ***REMOVED***

            var markerItem = await _repository.AddAsync(marker);

            // SignalR event
            await _hubContext.Clients.All.SendAsync("GetNewMarker", markerItem);

            return Ok(markerItem);
       ***REMOVED***

        // Delete: api/markers/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> Delete(int id)
        ***REMOVED***
            var markerItem = _repository.GetByIdAsync<Marker>(id).Result;
            if (markerItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            await _repository.DeleteAsync<Marker>(markerItem);
            return NoContent();

       ***REMOVED***
   ***REMOVED***
***REMOVED***