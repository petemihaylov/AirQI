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
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public RolesController(IEFRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET api/roles
        [HttpGet]
        public ActionResult <IEnumerable<RoleReadDto>> GetAllRoles()
        {
            var roleItems = _repository.GetAllAsync<Role>();
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(roleItems.Result));
        }

        // GET api/roles/{id}
        [HttpGet("{id}", Name="GetRoleById")]
        public ActionResult <RoleReadDto> GetRoleById(int id)
        {
            var roleItem = _repository.GetByIdAsync<Role>(id);
            if(roleItem != null)
            {
                return Ok(_mapper.Map<RoleReadDto>(roleItem.Result)); 
            }
            return NotFound();
        }



        // POST api/role
        [HttpPost]
        public ActionResult<Role> CreateRole(RoleCreateDto roleCreateDto)
        {

            var roleItem = _mapper.Map<Role>(roleCreateDto);
            if(_repository.Exists<Role>(roleItem))
            {
                    return Conflict();
            }
            this._repository.AddAsync<Role>(roleItem);

            
            var roleReadDto = _mapper.Map<RoleReadDto>(roleItem);
            return CreatedAtRoute(nameof(GetRoleById), new {Id = roleReadDto.Id}, roleReadDto);
        }


        // DELETE api/roles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRole(int id)
        {
            var roleItem = _repository.GetByIdAsync<Role>(id);
            if(roleItem == null)
            {
                return NotFound();
            }

            _repository.DeleteAsync<Role>(roleItem.Result);
            return NoContent();
        }

    }
}