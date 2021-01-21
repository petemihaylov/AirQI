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
***REMOVED***
    [Produces("application/json")]
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    ***REMOVED***
        private readonly IMongoDataRepository<Notification> _repository;
        // private readonly IHubContext<LiveStationHub> _hub;
        private readonly IMapper _mapper;

        public NotificationsController(IMongoDataRepository<Notification> repository, IMapper mapper)
        ***REMOVED***
            this._mapper = mapper;
            this._repository = repository;
       ***REMOVED***

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        ***REMOVED***
            var notifications = await this._repository.GetAllAsync();

            if (notifications != null)
            ***REMOVED***
                notifications = notifications.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new ***REMOVED*** doc.Position***REMOVED***, (key, group) => group.First());
                return Ok(this._mapper.Map<IEnumerable<NotificationReadDto>>(notifications));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id:string***REMOVED***", Name = "GetNotificationById")]
        public async Task<IActionResult> GetNotificationById(string id)
        ***REMOVED***
            var notifications = await this._repository.GetAllAsync();
            

            if (notifications != null)
            ***REMOVED***
                var notification = notifications.ToList().Find(doc => doc.Id.ToString() == id);
                return Ok(this._mapper.Map<NotificationReadDto>(notification));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationCreateDto notificationCreateDto)
        ***REMOVED***
            var notification = this._mapper.Map<Notification>(notificationCreateDto);

            await this._repository.CreateObjectAsync(notification);

            var notificationReadDto = _mapper.Map<NotificationReadDto>(notification);

            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetNotificationById), new ***REMOVED*** Id = notificationReadDto.Id***REMOVED***, notificationReadDto);
       ***REMOVED***

        [HttpPut("***REMOVED***id:string***REMOVED***")]
        public async Task<IActionResult> UpdateNotificationById(string id, NotificationCreateDto notificationCreateDto)
        ***REMOVED***
            var notificationModel = this._mapper.Map<Notification>(notificationCreateDto);
            var notification = await this._repository.GetObjectByIdAsync(id);

            if (notification != null)
            ***REMOVED***
                notificationModel.Id = new ObjectId(id);
                notificationModel.UpdatedAt = DateTime.UtcNow;
                await this._repository.UpdateObjectAsync(id, notificationModel);
                return Ok(this._mapper.Map<Notification>(notificationModel));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpDelete("***REMOVED***id:string***REMOVED***")]
        public async Task<ActionResult> DeleteNotification(string id)
        ***REMOVED***
            var notification = await this._repository.GetObjectByIdAsync(id);

            if (notification != null)
            ***REMOVED***
                await this._repository.RemoveObjectAsync(notification);
                return Ok("Successfully deleted from collection!");
           ***REMOVED***

            return NotFound();
       ***REMOVED***
   ***REMOVED***
***REMOVED***