using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarkerService.Domain;
using MarkerService.Data.Interfaces;

namespace ApiBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlaMarkersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public SlaMarkersController(IUnitOfWork uow)
        {
            this._uow = uow;
        }


        // GET api/sla markers
        [HttpGet]
        public ActionResult<IEnumerable<SlaMarker>> GetAllSlaMarkers()
        {
            return Ok(_uow.SlaMarkers.GetAll());
        }


        // GET api/sla markers/{id}
        [HttpGet("{id}", Name = "GetSlaMarkerById")]
        public ActionResult<SlaMarker> GetSlaMarkerById(int id)
        {
            var _sla = _uow.SlaMarkers.GetById(id);

            return _sla != null ?  Ok(_sla) : NotFound();
        }


        // POST api/sla markers
        [HttpPost]
        public ActionResult<SlaMarker> CreateSlaMarker(SlaMarker slaMarker)
        {
            var _sla = _uow.SlaMarkers.AddSlaMarker(slaMarker);
            _uow.Complete();
            return Ok(_sla);
        }


        // PUT api/sla markers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSlaMarker(int id, SlaMarker slaMarker)
        {
            var repoSla = _uow.SlaMarkers.GetById(id);
            if (repoSla == null)
            {
                return NotFound();
            }

            _uow.SlaMarkers.Update(slaMarker);
            _uow.Complete();
            return Ok();
        }


        // DELETE api/sla markers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSlaMarker(int id)
        {
            var _slaItem = _uow.SlaMarkers.GetById(id);
            if (_slaItem == null)
            {
                return NotFound();
            }

            _uow.SlaMarkers.Remove(_slaItem);
            _uow.Complete();
            return Ok();
        }
    }
}