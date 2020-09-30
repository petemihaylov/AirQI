using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.DTOs;
using System.Threading.Tasks;

namespace ApiBase.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public UsersController(IEFRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        // GET api/users
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAllAsync<User>();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems.Result));
        }


        // GET api/users/{id}
        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetByIdAsync<User>(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem.Result)); 
            }
            return NotFound();
        }


        // POST api/users
        [HttpPost]
        public ActionResult <User> CreateUser(UserCreateDto userCreateDto)
        {
            var userItem = _mapper.Map<User>(userCreateDto);
            
            if(_repository.Exists<User>(userItem))
            {
                return Conflict();
            }
            
            this._repository.AddAsync<User>(userItem);
            var userReadDto = _mapper.Map<UserReadDto>(userItem);

            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);
        }
    
        
        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userItem = _repository.GetByIdAsync<User>(id);
            if(userItem.Result == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userItem.Result);

            _repository.UpdateAsync<User>(userItem.Result);
            
            return NoContent();
        }
 

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userItem = _repository.GetByIdAsync<User>(id);
            if(userItem == null)
            {
                return NotFound();
            }

            _repository.DeleteAsync<User>(userItem.Result);

            return NoContent();
        }
    }
}