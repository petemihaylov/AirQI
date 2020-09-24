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
    public class RolesController : ControllerBase
    ***REMOVED***
        private readonly IApplicationRepo _repository;

        public readonly IMapper _mapper;

        public RolesController(IApplicationRepo repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***

        // GET api/roles
        [HttpGet]
        public ActionResult <IEnumerable<RoleReadDto>> GetAllRoles()
        ***REMOVED***
            var roleItems = _repository.GetAllRoles();
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(roleItems));
       ***REMOVED***


        // POST api/role
        [HttpPost]
        public void CreateRole(RoleCreateDto roleCreateDto)
        ***REMOVED***
            var roleModel = _mapper.Map<Role>(roleCreateDto);
            this._repository.CreateRole(roleModel);
            this._repository.SaveChanges();
       ***REMOVED***
   ***REMOVED***
***REMOVED***