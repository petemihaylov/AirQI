using ApiBase.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiBase.Models;

namespace ApiBase.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SlaMarkersController : ControllerBase
    {
        private readonly ISlaMarkerService _slaMarkerService;

        public SlaMarkersController(ISlaMarkerService slaService)
        {
            this._slaMarkerService = slaService;
        }


        // GET api/slamarkers
        [HttpGet]
        public ActionResult<IEnumerable<SlaMarker>> GetAllSlaMarkers()
        {
            return Ok(_slaMarkerService.GetSlaMarkers());
        }


        // GET api/slamarkers/{id}
        [HttpGet("{id}", Name = "GetSlaMarkerById")]
        public ActionResult<SlaMarker> GetSlaMarkerById(int id)
        {
            var _sla = _slaMarkerService.GetSlaMarkerById(id);

            if (_sla != null) return Ok(_sla);
            else return NotFound();
        }


        // POST api/slamarkers
        [HttpPost]
        public ActionResult<SlaMarker> CreateSlaMarker(SlaMarker slaMarker)
        {
            var _sla = _slaMarkerService.AddSlaMarker(slaMarker);

            return Ok(_sla);
            //return  CreatedAtRoute(nameof(GetSlaMarkerById), new { id = _sla.Id }, _sla);
        }


        // PUT api/slamarkers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSlaMarker(int id, SlaMarker slaMarker)
        {
            var repoSla = _slaMarkerService.GetSlaMarkerById(id);
            if (repoSla == null)
            {
                return NotFound();
            }

            _slaMarkerService.UpdateSlaMarker(slaMarker);

            return Ok();
        }


        // DELETE api/slamarkers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSlaMarker(int id)
        {
            var _slaItem = _slaMarkerService.GetSlaMarkerById(id);
            if (_slaItem == null)
            {
                return NotFound();
            }

            _slaMarkerService.DeleteSlaMarker(_slaItem);
            return Ok();
        }
    }
}