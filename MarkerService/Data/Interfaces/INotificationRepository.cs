using MarkerService.Domain;

namespace MarkerService.Data.Interfaces
{
   public interface INotificationRepository : IGenericRepository<Notification>
    {
        Notification AddNotification(Notification notification);
    }
}
