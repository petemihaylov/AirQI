using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.DTOs;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ApiBase.Controllers
***REMOVED***
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    ***REMOVED***
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public UsersController(IEFRepository repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        ***REMOVED***
            var userItems = _repository.GetAllAsync<User>();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems.Result));
       ***REMOVED***


        // GET api/users/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        ***REMOVED***
            var userItem = _repository.GetByIdAsync<User>(id);
            if (userItem != null)
            ***REMOVED***
                return Ok(_mapper.Map<UserReadDto>(userItem.Result));
           ***REMOVED***
            return NotFound();
       ***REMOVED***


        // POST api/users
        [HttpPost]
        public ActionResult<User> CreateUser(UserCreateDto userCreateDto)
        ***REMOVED***
            var userItem = _mapper.Map<User>(userCreateDto);

            foreach (var user in _repository.GetAllAsync<User>().Result)
            ***REMOVED***
                if (user.Username == userItem.Username) return Conflict(new ***REMOVED***message = "There is an existing record with the same username. Try something different!"***REMOVED***);
           ***REMOVED***

            if (_repository.Exists<User>(userItem))
            ***REMOVED***
                return Conflict();
           ***REMOVED***

            this._repository.AddAsync<User>(userItem);
            

            var userReadDto = _mapper.Map<UserReadDto>(userItem);

            return CreatedAtRoute(nameof(GetUserById), new ***REMOVED*** Id = userReadDto.Id***REMOVED***, userReadDto);
       ***REMOVED***


        // PUT api/users/***REMOVED***id***REMOVED***
        [HttpPut("***REMOVED***id***REMOVED***")]
        public ActionResult UpdateUser(int id, UserCreateDto userUpdateDto)
        ***REMOVED***
            var userItem = _repository.GetByIdAsync<User>(id);
            if (userItem.Result == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _mapper.Map(userUpdateDto, userItem.Result);

            _repository.UpdateAsync<User>(userItem.Result);

            return NoContent();
       ***REMOVED***


        // DELETE api/users/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public ActionResult DeleteUser(int id)
        ***REMOVED***
            var userItem = _repository.GetByIdAsync<User>(id);
            if (userItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _repository.DeleteAsync<User>(userItem.Result);

            return NoContent();
       ***REMOVED***
   ***REMOVED***
***REMOVED***