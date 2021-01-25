
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBase.DTOs;
using ApiBase.Models;

namespace ApiBase.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        User GetUserById(int id);

        UserDto AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto, User repoUser);
        void DeleteUser(User userDto);
        bool IsValid(UserDto userDto);
        bool UserExists(UserDto userDto);
    }
}