using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.DTOs;
using System.Threading.Tasks;

namespace ApiBase.Controllers
***REMOVED***
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    ***REMOVED***
        private readonly IApplicationRepo _repository;
        public readonly IMapper _mapper;

        public UsersController(IApplicationRepo repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***


        // GET api/users
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        ***REMOVED***
            var userItems = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
       ***REMOVED***


        // GET api/users/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name="GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        ***REMOVED***
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            ***REMOVED***
                return Ok(_mapper.Map<UserReadDto>(userItem)); 
           ***REMOVED***
            return NotFound();
       ***REMOVED***


        // POST api/users
        [HttpPost]
        public async Task<ActionResult <User>> CreateUser(UserCreateDto userCreateDto)
        ***REMOVED***
            var userModel = _mapper.Map<User>(userCreateDto);
            await this._repository.CreateUser(userModel);
            
            if(_repository.Exists(userModel) == true)
            ***REMOVED***
                return Conflict();
           ***REMOVED***
            
            await this._repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new ***REMOVED***Id = userReadDto.UserId***REMOVED***, userReadDto);
       ***REMOVED***
    
        
        // PUT api/users/***REMOVED***id***REMOVED***
        [HttpPut("***REMOVED***id***REMOVED***")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        ***REMOVED***
            var userRepo = _repository.GetUserById(id);
            if(userRepo == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _mapper.Map(userUpdateDto, userRepo);

            _repository.UpdateUser(userRepo);
            
            await _repository.SaveChanges();

            return NoContent();

       ***REMOVED***
 

        // DELETE api/users/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public async Task<ActionResult> DeleteUser(int id)
        ***REMOVED***
            var userRepo = _repository.GetUserById(id);
            if(userRepo == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _repository.DeleteUser(userRepo);
            await _repository.SaveChanges();

            return NoContent();
       ***REMOVED***
   ***REMOVED***
***REMOVED***