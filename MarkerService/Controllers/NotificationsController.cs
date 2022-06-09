
using System;
using MarkerService.Data.Interfaces;
using MarkerService.DataTransfer;
using MarkerService.Domain;
using MarkerService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IHubContext<LiveNotificationHub> _hubNotificationContext;

        public NotificationsController(IUnitOfWork uow, IHubContext<LiveNotificationHub> hubNotificationContext)
        {
            this._uow = uow;
            this._hubNotificationContext = hubNotificationContext;
        }

        // GET: api/notifications
        [HttpGet]
        public ActionResult<Notification> GetNotifications()
        {
            var notifications = _uow.Notifications.GetAll();

            return Ok(notifications);
        }

        // GET api/notifications/{id}
        [HttpGet("{id}", Name = "GetNotificationById")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var item = _uow.Notifications.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST: api/notifications
        [HttpPost]
        public ActionResult<Notification> AddNotification(Notification notification)
        {
            var item = _uow.Notifications.AddNotification(notification);
            _uow.Complete();

            var signalNotification = new NotificationDto
            {
                Title = item.Title,
                Description = item.Description,
                Type = item.Type,
                CreatedAt = DateTime.UtcNow.ToString()
            };
            _hubNotificationContext.Clients.All.SendAsync("GetNewNotification", signalNotification);

            return CreatedAtRoute(nameof(GetNotificationById), new { id = item.Id }, item);
        }

        // DELETE: api/notifications/{id}
        [HttpDelete("{id}")]
        public ActionResult<Notification> Delete(int id)
        {
            var item = _uow.Notifications.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _uow.Notifications.Remove(item);
            _uow.Complete();
            return NoContent();

        }
    }
}