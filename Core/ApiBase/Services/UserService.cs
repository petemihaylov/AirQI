using System.Collections.Generic;
using ApiBase.Services.Interfaces;
using ApiBase.Models;
using ApiBase.Data;
using ApiBase.DTOs;
using AutoMapper;

namespace ApiBase.Services
***REMOVED***
    public class UserService : IUserService
    ***REMOVED***
        private readonly IEFRepository _repository;
        public readonly IMapper _mapper;

        public UserService(IEFRepository repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***

        public UserDto AddUser(UserDto userDto)
        ***REMOVED***
            var user = _mapper.Map<User>(userDto);

           this._repository.AddAsync<User>(user);

            return userDto;
       ***REMOVED***

        public void DeleteUser(User user)
        ***REMOVED***
            _repository.DeleteAsync<User>(user);
       ***REMOVED***

        public User GetUserById(int id)
        ***REMOVED***
            return _repository.GetByIdAsync<User>(id).Result;
       ***REMOVED***

        public IEnumerable<UserDto> GetUsers()
        ***REMOVED***
            var userItems = _repository.GetAllAsync<User>();
            return _mapper.Map<IEnumerable<UserDto>>(userItems.Result);
       ***REMOVED***

        public bool IsValid(UserDto userDto)
        ***REMOVED***
            var user = _mapper.Map<User>(userDto);

            foreach (var u in GetUsers())
            ***REMOVED***
                if (user.Username == u.Username) return false;
           ***REMOVED***
            return true;
       ***REMOVED***

        public void UpdateUser(UserDto userDto, User repoUser)
        ***REMOVED***
            _mapper.Map(userDto, repoUser);
            _repository.UpdateAsync<User>(repoUser);
       ***REMOVED***

        public bool UserExists(UserDto userDto)
        ***REMOVED***
            var user = _mapper.Map<User>(userDto);
            return _repository.Exists<User>(user);
       ***REMOVED***
   ***REMOVED***
***REMOVED***