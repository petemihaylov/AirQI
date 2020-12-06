using ApiBase.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiBase.Models;
using ApiBase.DTOs;

namespace ApiBase.Controllers
***REMOVED***
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    ***REMOVED***
        private readonly IUserService _userService;
        public UsersController(IUserService userService) ***REMOVED*** this._userService = userService;***REMOVED***


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        ***REMOVED***
            return Ok(_userService.GetUsers());
       ***REMOVED***


        // GET api/users/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetUserById")]
        public ActionResult<UserDto> GetUserById(int id)
        ***REMOVED***
            var user = _userService.GetUserById(id);

            if (user != null) return Ok(user);
            else return NotFound();
       ***REMOVED***


        // POST api/users
        [HttpPost]
        public ActionResult<User> CreateUser(UserDto userDto)
        ***REMOVED***

            if (_userService.IsValid(userDto) == false)
                return Conflict(new ***REMOVED*** message = "There is an existing record with the same username. Try something different!"***REMOVED***);

            if (_userService.UserExists(userDto))
                return Conflict();

            var user = _userService.AddUser(userDto);

            return CreatedAtRoute(nameof(GetUserById), new ***REMOVED*** Id = user.Id***REMOVED***, user);
       ***REMOVED***


        // PUT api/users/***REMOVED***id***REMOVED***
        [HttpPut("***REMOVED***id***REMOVED***")]
        public ActionResult UpdateUser(int id, UserDto userDto)
        ***REMOVED***
            var repoUser = _userService.GetUserById(id);
            if (repoUser == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _userService.UpdateUser(userDto, repoUser);

            return Ok();
       ***REMOVED***


        // DELETE api/users/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public ActionResult DeleteUser(int id)
        ***REMOVED***
            var userItem = _userService.GetUserById(id);
            if (userItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _userService.DeleteUser(userItem);
            return Ok();
       ***REMOVED***
   ***REMOVED***
***REMOVED***