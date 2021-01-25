using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQi.Dtos.Data;
using AirQi.Hubs;
using AirQi.Models.Data;
using AirQi.Repository.Core;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;

namespace AirQi.Controllers
{
    [Produces("application/json")]
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMongoDataRepository<Notification> _repository;
        private readonly IHubContext<LiveNotificationHub> _hub;
        private readonly IMapper _mapper;

        public NotificationsController(IMongoDataRepository<Notification> repository, IHubContext<LiveNotificationHub> hub, IMapper mapper)
        {
            this._mapper = mapper;
            this._hub = hub;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await this._repository.GetAllAsync();

            if (notifications != null)
            {
                notifications = notifications.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new { doc.Position }, (key, group) => group.First());
                return Ok(this._mapper.Map<IEnumerable<NotificationReadDto>>(notifications));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetNotificationById")]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            var notification = await this._repository.GetObjectByIdAsync(id);
            

            if (notification != null)
            {
                return Ok(this._mapper.Map<NotificationReadDto>(notification));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationCreateDto notificationCreateDto)
        {
            var notification = this._mapper.Map<Notification>(notificationCreateDto);

            if (notification != null)
            {
                notification.Id = ObjectId.GenerateNewId();
                notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;
                await this._repository.CreateObjectAsync(notification);

                // SignalR event
                // await this._hub.Clients.All.SendAsync("GetNewNotificationsAsync", notification);

                return Ok(this._mapper.Map<NotificationReadDto>(notification));
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(string id, NotificationCreateDto notificationCreateDto)
        {
            var notificationModel = this._mapper.Map<Notification>(notificationCreateDto);
            var notification = await this._repository.GetObjectByIdAsync(id);

            if (notification != null)
            {
                notificationModel.Id = new ObjectId(id);
                notificationModel.UpdatedAt = DateTime.UtcNow;
                await this._repository.UpdateObjectAsync(id, notificationModel);
                
                return Ok(this._mapper.Map<NotificationReadDto>(notificationModel));
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNotification(string id)
        {
            var notification = await this._repository.GetObjectByIdAsync(id);

            if (notification != null)
            {
                await this._repository.RemoveObjectAsync(notification);
                return Ok("Successfully deleted from collection!");
            }

            return NotFound();
        }
    }
}