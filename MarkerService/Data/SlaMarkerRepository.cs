using MarkerService.Data.Interfaces;
using MarkerService.Domain;

namespace MarkerService.Data
{
    public class SlaMarkerRepository : GenericRepository<SlaMarker>, ISlaMarkerRepository
    {
        public SlaMarkerRepository(ApplicationDbContext context) : base(context)
        {
        }
        public SlaMarker AddSlaMarker(SlaMarker slaMarker) => _context.SlaMarkers.Add(slaMarker).Entity;
    }
}