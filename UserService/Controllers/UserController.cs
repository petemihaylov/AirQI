
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.AsyncDataServices;
using UserService.Data.Interfaces;
using UserService.DataTransfer;
using UserService.Domain;

namespace ApiBase.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public readonly  IMessageBusClient _messageBusClient;
        public UsersController(IUnitOfWork uow, IMapper mapper, IMessageBusClient messageBusClient) { this._uow = uow; this._mapper = mapper; this._messageBusClient = messageBusClient; }


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_uow.Users.GetAll());
        }


        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _uow.Users.GetById(id);
            return (user != null) ? Ok(user) : NotFound();
        }


        // POST api/users
        [HttpPost]
        public ActionResult<User> CreateUser(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            if (_uow.Users.DemandUserExist(userDto.Username))
                return Conflict(new { message = $"There is an existing user with the same username {userDto.Username}!" });

            var user = _uow.Users.AddUser(_mapper.Map<User>(userDto));
            _uow.Complete();

            try {
                var userPublishDto = _mapper.Map<UserPublishDto>(user);
                userPublishDto.Event = "User_Published";
                _messageBusClient.PublishNewUser(userPublishDto);
            }catch (Exception e) {
                System.Console.WriteLine($"{e.Message}");
            }
            return CreatedAtRoute(nameof(GetUserById), new { id = user.Id }, user);
        }


        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(User user)
        {
            if (_uow.Users.GetById(user.Id) == null)
            {
                return NotFound();
            }

            _uow.Users.UpdateUser(user);
            _uow.Complete();
            return Ok(user);
        }


        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUserById(int id)
        {
            var user = _uow.Users.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _uow.Users.Remove(user);
            _uow.Complete();
            return Ok(user);
        }
    }
}