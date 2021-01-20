using ApiBase.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiBase.Models;

namespace ApiBase.Controllers
***REMOVED***
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SlaMarkersController : ControllerBase
    ***REMOVED***
        private readonly ISlaMarkerService _slaMarkerService;

        public SlaMarkersController(ISlaMarkerService slaService)
        ***REMOVED***
            this._slaMarkerService = slaService;
       ***REMOVED***


        // GET api/slamarkers
        [HttpGet]
        public ActionResult<IEnumerable<SlaMarker>> GetAllSlaMarkers()
        ***REMOVED***
            return Ok(_slaMarkerService.GetSlaMarkers());
       ***REMOVED***


        // GET api/slamarkers/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetSlaMarkerById")]
        public ActionResult<SlaMarker> GetSlaMarkerById(int id)
        ***REMOVED***
            var _sla = _slaMarkerService.GetSlaMarkerById(id);

            if (_sla != null) return Ok(_sla);
            else return NotFound();
       ***REMOVED***


        // POST api/slamarkers
        [HttpPost]
        public ActionResult<SlaMarker> CreateSlaMarker(SlaMarker slaMarker)
        ***REMOVED***
            var _sla = _slaMarkerService.AddSlaMarker(slaMarker);

            return Ok(_sla);
            //return  CreatedAtRoute(nameof(GetSlaMarkerById), new ***REMOVED*** id = _sla.Id***REMOVED***, _sla);
       ***REMOVED***


        // PUT api/slamarkers/***REMOVED***id***REMOVED***
        [HttpPut("***REMOVED***id***REMOVED***")]
        public ActionResult UpdateSlaMarker(int id, SlaMarker slaMarker)
        ***REMOVED***
            var repoSla = _slaMarkerService.GetSlaMarkerById(id);
            if (repoSla == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _slaMarkerService.UpdateSlaMarker(slaMarker);

            return Ok();
       ***REMOVED***


        // DELETE api/slamarkers/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public ActionResult DeleteSlaMarker(int id)
        ***REMOVED***
            var _slaItem = _slaMarkerService.GetSlaMarkerById(id);
            if (_slaItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _slaMarkerService.DeleteSlaMarker(_slaItem);
            return Ok();
       ***REMOVED***
   ***REMOVED***
***REMOVED***