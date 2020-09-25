using ApiBase.DTOs;
using ApiBase.Models;
using AutoMapper;

namespace Commander.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            // source to destionation
            CreateMap<Role, RoleReadDto>();
            CreateMap<RoleCreateDto, Role>();
        }
    }
}