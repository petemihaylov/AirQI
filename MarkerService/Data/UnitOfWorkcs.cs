using MarkerService.Data.Interfaces;

namespace MarkerService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMarkerRepository Markers { get; private set; }
        public ISlaMarkerRepository SlaMarkers {get; private set;}

        public INotificationRepository Notifications {get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Markers = new MarkerRepository(_context);
            Notifications = new NotificationRepository(_context);
            SlaMarkers = new SlaMarkerRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
