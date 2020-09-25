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

        // GET api/roles/{id}
        [HttpGet("{id}", Name="GetRoleById")]
        public ActionResult <RoleReadDto> GetRoleById(int id)
        {
            var roleItem = _repository.GetRoleById(id);
            if(roleItem != null)
            {
                return Ok(_mapper.Map<RoleReadDto>(roleItem)); 
            }
            return NotFound();
        }



        // POST api/role
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(RoleCreateDto roleCreateDto)
        {

            var roleModel = _mapper.Map<Role>(roleCreateDto);
            await this._repository.CreateRole(roleModel);

            if(_repository.Exists(roleModel) == false)
            {
                    return Conflict();
            }
            
            await this._repository.SaveChanges();
        
            var roleReadDto = _mapper.Map<RoleReadDto>(roleModel);
            return CreatedAtRoute(nameof(GetRoleById), new {Id = roleReadDto.RoleId}, roleReadDto);
        }


        // DELETE api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var roleRepo = _repository.GetRoleById(id);
            if(roleRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteRole(roleRepo);
            await _repository.SaveChanges();

            return NoContent();
        }

    }
}