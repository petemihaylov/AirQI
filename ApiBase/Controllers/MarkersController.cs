
using System.Threading.Tasks;
using ApiBase.Data;
using ApiBase.Hubs;
using ApiBase.Models;
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

        public MarkersController(IEFRepository repository, IHubContext<LiveMarkerHub> hubContext)
        ***REMOVED***
            this._repository = repository;
            this._hubContext = hubContext;
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
        public async Task<IActionResult> AddMarker(Marker message)
        ***REMOVED***
            var markerItem = await _repository.AddAsync(message);

            // SignalR event
            await _hubContext.Clients.All.SendAsync("GetNewMarker", markerItem);

            return Ok();
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