using AuthService.DataTransfer;
using AuthService.Domain;
using AutoMapper;
using UserService.DataTransfer;

namespace AuthService.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<User, UserDto>();
      CreateMap<UserDto, User>();
      CreateMap<UserConsumeDto, User>();
    }
  }
}