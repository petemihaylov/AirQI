using System.Collections.Generic;
using ApiBase.Services.Interfaces;
using ApiBase.Models;
using ApiBase.Data;
using ApiBase.DTOs;
using AutoMapper;

namespace ApiBase.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public UserService(IEFRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public UserDto AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

           this._repository.AddAsync<User>(user);

            return userDto;
        }

        public void DeleteUser(User user)
        {
            _repository.DeleteAsync<User>(user);
        }

        public User GetUserById(int id)
        {
            return _repository.GetByIdAsync<User>(id).Result;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var userItems = _repository.GetAllAsync<User>();
            return _mapper.Map<IEnumerable<UserDto>>(userItems.Result);
        }

        public bool IsValid(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            foreach (var u in GetUsers())
            {
                if (user.Username == u.Username) return false;
            }
            return true;
        }

        public void UpdateUser(UserDto userDto, User repoUser)
        {
            _mapper.Map(userDto, repoUser);
            _repository.UpdateAsync<User>(repoUser);
        }

        public bool UserExists(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return _repository.Exists<User>(user);
        }
    }
}