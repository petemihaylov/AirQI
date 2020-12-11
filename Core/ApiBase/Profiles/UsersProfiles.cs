using ApiBase.DTOs;
using ApiBase.Models;
using AutoMapper;

namespace Commander.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // source to destionation
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}