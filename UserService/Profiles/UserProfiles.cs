using UserService.DataTransfer;
using UserService.Domain;
using AutoMapper;

namespace UserService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserPublishDto>();
        }
    }
}