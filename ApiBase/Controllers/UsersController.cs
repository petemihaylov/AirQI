using ApiBase.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiBase.Models;
using ApiBase.DTOs;

namespace ApiBase.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) { this._userService = userService; }


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            return Ok(_userService.GetUsers());
        }


        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user != null) return Ok(user);
            else return NotFound();
        }


        // POST api/users
        [HttpPost]
        public ActionResult<User> CreateUser(UserDto userDto)
        {

            if (_userService.IsValid(userDto) == false)
                return Conflict(new { message = "There is an existing record with the same username. Try something different!" });

            if (_userService.UserExists(userDto))
                return Conflict();

            var user = _userService.AddUser(userDto);

            return CreatedAtRoute(nameof(GetUserById), new { Id = user.Id }, user);
        }


        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserDto userDto)
        {
            var repoUser = _userService.GetUserById(id);
            if (repoUser == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(userDto, repoUser);

            return Ok();
        }


        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userItem = _userService.GetUserById(id);
            if (userItem == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(userItem);
            return Ok();
        }
    }
}