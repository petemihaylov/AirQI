
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AuthService.Data.Interfaces;
using AuthService.Domain;
using System;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public UsersController(IUnitOfWork uow) { _uow = uow;}


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try{
                return Ok(_uow.Users.GetAll());
            }catch (Exception e)
            {
                return Conflict($"User not found. {e.Message}");
            }
        }
    }
}