using System;

namespace MarkerService.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMarkerRepository Markers { get; }
        ISlaMarkerRepository SlaMarkers { get; }
        INotificationRepository Notifications {get;}
        int Complete();
    }
}
