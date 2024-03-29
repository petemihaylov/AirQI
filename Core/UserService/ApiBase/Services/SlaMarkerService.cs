using ApiBase.Data;
using ApiBase.Models;
using System.Collections.Generic;
using ApiBase.Services.Interfaces;

namespace ApiBase.Services
{
    public class SlaMarkerService : ISlaMarkerService
    {
        private readonly IEFRepository _repository;

        public SlaMarkerService(IEFRepository repository)
        {
            this._repository = repository;
        }
        public SlaMarker AddSlaMarker(SlaMarker slaMarker)
        {
           var _sla = this._repository.AddAsync<SlaMarker>(slaMarker);
           return _sla.Result;
        }

        public void DeleteSlaMarker(SlaMarker slaMarker)
        {
            _repository.DeleteAsync<SlaMarker>(slaMarker);
        }

        public SlaMarker GetSlaMarkerById(int id)
        {
            return _repository.GetByIdAsync<SlaMarker>(id).Result;
        }

        public IEnumerable<SlaMarker> GetSlaMarkers()
        {
            var _slaItems = this._repository.GetAllAsync<SlaMarker>();
            return _slaItems.Result;
        }

        public void UpdateSlaMarker(SlaMarker slaMarker)
        {
            throw new System.NotImplementedException();
        }
    }
}