using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQi.Dtos;
using AirQi.Models.Data;
using AirQi.Repository.Core;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AssetNXT.Controllers
{
    [Produces("application/json")]
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMongoDataRepository<Notification> _repository;
        // private readonly IHubContext<LiveStationHub> _hub;
        private readonly IMapper _mapper;

        public NotificationsController(IMongoDataRepository<Notification> repository, IMapper mapper)
        {
            this._mapper = mapper;
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

        [HttpGet("{id:string}", Name = "GetNotificationById")]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            var notifications = await this._repository.GetAllAsync();
            

            if (notifications != null)
            {
                var notification = notifications.ToList().Find(doc => doc.Id.ToString() == id);
                return Ok(this._mapper.Map<NotificationReadDto>(notification));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationCreateDto notificationCreateDto)
        {
            var notification = this._mapper.Map<Notification>(notificationCreateDto);

            await this._repository.CreateObjectAsync(notification);

            var notificationReadDto = _mapper.Map<NotificationReadDto>(notification);

            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetNotificationById), new { Id = notificationReadDto.Id }, notificationReadDto);
        }

        [HttpPut("{id:string}")]
        public async Task<IActionResult> UpdateNotificationById(string id, NotificationCreateDto notificationCreateDto)
        {
            var notificationModel = this._mapper.Map<Notification>(notificationCreateDto);
            var notification = await this._repository.GetObjectByIdAsync(id);

            if (notification != null)
            {
                notificationModel.Id = new ObjectId(id);
                notificationModel.UpdatedAt = DateTime.UtcNow;
                await this._repository.UpdateObjectAsync(id, notificationModel);
                return Ok(this._mapper.Map<Notification>(notificationModel));
            }

            return NotFound();
        }

        [HttpDelete("{id:string}")]
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