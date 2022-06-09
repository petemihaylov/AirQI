using System.Collections.Generic;
using System.Linq;
using MarkerService.Data.Interfaces;
using MarkerService.Domain;

namespace MarkerService.Data
{
    public class MarkerRepository : GenericRepository<Marker>, IMarkerRepository
    {
        public MarkerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Marker> GetAllMarkers()
        {
            return _context.Markers;
        }

        public Marker UpdateMarker(Marker marker) => _context.Markers.Update(marker).Entity;

        public bool DemandMarkerExist(int id) => _context.Markers.Where(m => m.Id.Equals(id)).Any();

        public Marker DeleteMarker(Marker marker) => _context.Markers.Remove(marker).Entity;
        public Marker AddMarker(Marker marker) => _context.Markers.Add(marker).Entity;
    }
}