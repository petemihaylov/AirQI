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

        // GET api/roles/***REMOVED***id***REMOVED***
        [HttpGet("***REMOVED***id***REMOVED***", Name="GetRoleById")]
        public ActionResult <RoleReadDto> GetRoleById(int id)
        ***REMOVED***
            var roleItem = _repository.GetRoleById(id);
            if(roleItem != null)
            ***REMOVED***
                return Ok(_mapper.Map<RoleReadDto>(roleItem)); 
           ***REMOVED***
            return NotFound();
       ***REMOVED***



        // POST api/role
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(RoleCreateDto roleCreateDto)
        ***REMOVED***

            var roleModel = _mapper.Map<Role>(roleCreateDto);
            await this._repository.CreateRole(roleModel);

            if(_repository.Exists(roleModel) == false)
            ***REMOVED***
                    return Conflict();
           ***REMOVED***
            
            await this._repository.SaveChanges();
        
            var roleReadDto = _mapper.Map<RoleReadDto>(roleModel);
            return CreatedAtRoute(nameof(GetRoleById), new ***REMOVED***Id = roleReadDto.RoleId***REMOVED***, roleReadDto);
       ***REMOVED***


        // DELETE api/roles/***REMOVED***id***REMOVED***
        [HttpDelete("***REMOVED***id***REMOVED***")]
        public async Task<ActionResult> DeleteRole(int id)
        ***REMOVED***
            var roleRepo = _repository.GetRoleById(id);
            if(roleRepo == null)
            ***REMOVED***
                return NotFound();
           ***REMOVED***

            _repository.DeleteRole(roleRepo);
            await _repository.SaveChanges();

            return NoContent();
       ***REMOVED***

   ***REMOVED***
***REMOVED***