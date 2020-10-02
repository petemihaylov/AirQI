using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiBase.Data;
using System.Collections.Generic;
using ApiBase.Models;
using ApiBase.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApiBase.Controllers
***REMOVED***
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    ***REMOVED***
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public RolesController(IEFRepository repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***

        // GET api/roles
        [HttpGet]
        public ActionResult <IEnumerable<RoleReadDto>> GetAllRoles()
        ***REMOVED***
            var roleItems = _repository.GetAllAsync<Role>();
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(roleItems.Result));
       ***REMOVED***

        // GET api/roles/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name="GetRoleById")]
        public ActionResult <RoleReadDto> GetRoleById(int id)
        ***REMOVED***
            var roleItem = _repository.GetByIdAsync<Role>(id);
            if(roleItem != null)
            ***REMOVED***
                return Ok(_mapper.Map<RoleReadDto>(roleItem.Result)); 
           ***REMOVED***
            return NotFound();
       ***REMOVED***



        // POST api/role
        [HttpPost]
        public ActionResult<Role> CreateRole(RoleCreateDto roleCreateDto)
        ***REMOVED***

            var roleItem = _mapper.Map<Role>(roleCreateDto);
            if(_repository.Exists<Role>(roleItem))
            ***REMOVED***
                    return Conflict();
           ***REMOVED***
            this._repository.AddAsync<Role>(roleItem);

            
            var roleReadDto = _mapper.Map<RoleReadDto>(roleItem);
            return CreatedAtRoute(nameof(GetRoleById), new ***REMOVED***Id = roleReadDto.Id***REMOVED***, roleReadDto);
       ***REMOVED***


        // DELETE api/roles/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public ActionResult DeleteRole(int id)
        ***REMOVED***
            var roleItem = _repository.GetByIdAsync<Role>(id);
            if(roleItem == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _repository.DeleteAsync<Role>(roleItem.Result);
            return NoContent();
       ***REMOVED***

   ***REMOVED***
***REMOVED***