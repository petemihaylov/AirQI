using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.Dto;

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
        public ActionResult <User> CreateUser(UserCreateDto userCreateDto)
        ***REMOVED***
             var userModel = _mapper.Map<User>(userCreateDto);
            this._repository.CreateUser(userModel);
            this._repository.SaveChanges();


            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new ***REMOVED***Id = userReadDto.UserId***REMOVED***, userReadDto);
       ***REMOVED***
    
    
   ***REMOVED***
***REMOVED***