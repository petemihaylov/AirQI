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
    public class RolesController : ControllerBase
    {
        private readonly IApplicationRepo _repository;

        public readonly IMapper _mapper;

        public RolesController(IApplicationRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET api/roles
        [HttpGet]
        public ActionResult <IEnumerable<RoleReadDto>> GetAllRoles()
        {
            var roleItems = _repository.GetAllRoles();
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(roleItems));
        }


        // POST api/role
        [HttpPost]
        public void CreateRole(RoleCreateDto roleCreateDto)
        {
            var roleModel = _mapper.Map<Role>(roleCreateDto);
            this._repository.CreateRole(roleModel);
            this._repository.SaveChanges();
        }
    }
}