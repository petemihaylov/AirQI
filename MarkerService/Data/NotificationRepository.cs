using MarkerService.Data.Interfaces;
using MarkerService.Domain;

namespace MarkerService.Data
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Notification AddNotification(Notification notification) => _context.Notifications.Add(notification).Entity;
    }
}