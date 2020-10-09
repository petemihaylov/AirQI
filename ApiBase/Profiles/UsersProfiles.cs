using ApiBase.DTOs;
using ApiBase.Models;
using AutoMapper;

namespace Commander.Profiles
***REMOVED***
    public class UsersProfile : Profile
    ***REMOVED***
        public UsersProfile()
        ***REMOVED***
            // source to destionation
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
       ***REMOVED***
   ***REMOVED***
***REMOVED***