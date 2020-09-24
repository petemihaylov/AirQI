using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.Dto;

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
        public ActionResult <User> CreateUser(UserCreateDto userCreateDto)
        {
             var userModel = _mapper.Map<User>(userCreateDto);
            this._repository.CreateUser(userModel);
            this._repository.SaveChanges();


            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.UserId}, userReadDto);
        }
    
    
    }
}