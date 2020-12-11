

using System.Threading.Tasks;
using ApiBase.Data;
using ApiBase.Hubs;
using ApiBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiBase.Controllers
***REMOVED***

    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    ***REMOVED***
        private readonly IEFRepository _repository;
        private readonly IHubContext<LiveNotificationHub> _hubContext;

        public NotificationsController(IEFRepository repository, IHubContext<LiveNotificationHub> hubContext)
        ***REMOVED***
            this._repository = repository;
            this._hubContext = hubContext;
       ***REMOVED***

        // GET: api/notifications
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        ***REMOVED***
            var notifications = await _repository.GetAllAsync<Notification>();

            return Ok(notifications);
       ***REMOVED***

        //GET api/notifications/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetNotificationById")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        ***REMOVED***
            var notificationItem = await _repository.GetByIdAsync<Notification>(id);
            if (notificationItem != null)
            ***REMOVED***
                return Ok(notificationItem);
           ***REMOVED***
            return NotFound();
       ***REMOVED***

        // POST: api/notifications
        [HttpPost]
        public async Task<IActionResult> AddNotification(Notification message)
        ***REMOVED***
            var notificationItem = await _repository.AddAsync(message);

            // SignalR event
            await _hubContext.Clients.All.SendAsync("GetNewNotification", notificationItem);

            return Ok();
            // return CreatedAtRoute(nameof(GetNotificationById), new ***REMOVED*** id = notificationItem.Id***REMOVED***, notificationItem);
       ***REMOVED***

        // Delete: api/notifications/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> Delete(int id)
        ***REMOVED***
            var notificationItem = _repository.GetByIdAsync<Notification>(id).Result;
            if (notificationItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            await _repository.DeleteAsync<Notification>(notificationItem);
            return NoContent();

       ***REMOVED***
   ***REMOVED***
***REMOVED***