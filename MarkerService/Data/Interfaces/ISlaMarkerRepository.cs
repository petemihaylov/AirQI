using MarkerService.Domain;

namespace MarkerService.Data.Interfaces
{
    public interface ISlaMarkerRepository : IGenericRepository<SlaMarker>
    {
        SlaMarker AddSlaMarker(SlaMarker slaMarker);
    }
}
