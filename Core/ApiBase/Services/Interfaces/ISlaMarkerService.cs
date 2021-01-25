
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBase.DTOs;
using ApiBase.Models;

namespace ApiBase.Services.Interfaces
{
    public interface ISlaMarkerService
    {
        IEnumerable<SlaMarker> GetSlaMarkers();
        SlaMarker GetSlaMarkerById(int id);
        SlaMarker AddSlaMarker(SlaMarker slaMarker);
        void UpdateSlaMarker(SlaMarker slaMarker);
        void DeleteSlaMarker(SlaMarker slaMarker);
    }
}