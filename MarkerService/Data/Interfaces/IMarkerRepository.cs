using System.Collections.Generic;
using MarkerService.Domain;

namespace MarkerService.Data.Interfaces
{
    public interface IMarkerRepository : IGenericRepository<Marker>
    {
        IEnumerable<Marker> GetAllMarkers();

        Marker UpdateMarker(Marker Marker);

        Marker DeleteMarker(Marker Marker);

        Marker AddMarker(Marker Marker);

        bool DemandMarkerExist(int id);
    }
}
