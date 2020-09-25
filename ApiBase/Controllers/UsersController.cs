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
        private readonly IApplicationRepo _repository;
        public readonly IMapper _mapper;

        public UsersController(IApplicationRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        // GET api/users
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }


        // GET api/users/{id}
        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem)); 
            }
            return NotFound();
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult <User>> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            await this._repository.CreateUser(userModel);
            
            if(_repository.Exists(userModel) == true)
            {
                return Conflict();
            }
            
            await this._repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.UserId}, userReadDto);
        }
    
        
        // PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userRepo = _repository.GetUserById(id);
            if(userRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userRepo);

            _repository.UpdateUser(userRepo);
            
            await _repository.SaveChanges();

            return NoContent();

        }
 

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userRepo = _repository.GetUserById(id);
            if(userRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(userRepo);
            await _repository.SaveChanges();

            return NoContent();
        }
    }
}