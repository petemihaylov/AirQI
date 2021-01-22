using ApiBase.Data;
using ApiBase.Models;
using System.Collections.Generic;
using ApiBase.Services.Interfaces;

namespace ApiBase.Services
***REMOVED***
    public class SlaMarkerService : ISlaMarkerService
    ***REMOVED***
        private readonly IEFRepository _repository;

        public SlaMarkerService(IEFRepository repository)
        ***REMOVED***
            this._repository = repository;
       ***REMOVED***
        public SlaMarker AddSlaMarker(SlaMarker slaMarker)
        ***REMOVED***
           var _sla = this._repository.AddAsync<SlaMarker>(slaMarker);
           
           return _sla.Result;
       ***REMOVED***

        public void DeleteSlaMarker(SlaMarker slaMarker)
        ***REMOVED***
            _repository.DeleteAsync<SlaMarker>(slaMarker);
       ***REMOVED***

        public SlaMarker GetSlaMarkerById(int id)
        ***REMOVED***
            return _repository.GetByIdAsync<SlaMarker>(id).Result;
       ***REMOVED***

        public IEnumerable<SlaMarker> GetSlaMarkers()
        ***REMOVED***
            var _slaItems = this._repository.GetAllAsync<SlaMarker>();
            return _slaItems.Result;
       ***REMOVED***

        public void UpdateSlaMarker(SlaMarker slaMarker)
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***
   ***REMOVED***
***REMOVED***