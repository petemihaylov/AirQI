using System;
using System.Threading.Tasks;
using ApiBase.Data;
using ApiBase.DTOs;
using ApiBase.Models;
using ApiBase.Services;
using AutoMapper;
using Moq;
using Xunit;

namespace ApiBase.Tests
***REMOVED***
    public class UserServiceTests
    ***REMOVED***

        private readonly UserService _sut;
        private readonly  Mock<IEFRepository> _efRepositoryMock = new Mock<IEFRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public UserServiceTests()
        ***REMOVED***
            _sut = new UserService(_efRepositoryMock.Object, _mapperMock.Object);
       ***REMOVED***

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenCustomerExists()
        ***REMOVED***
            // Arrange
            var userId = new Random().Next();

            var userMock = new User
            ***REMOVED***
                Id = userId,
                Username = "username",
                Password = "password",
                FirstName = "",
                LastName = "",
                UserRole = "User"
           ***REMOVED***;

           _efRepositoryMock.Setup(x => x.GetByIdAsync<User>(userId))
                .ReturnsAsync(userMock);

            // Act
            var user = _sut.GetUserById(userId);

            // Assert
            Assert.Equal(user.Id, userId);

       ***REMOVED***


        [Fact]
        public async Task GetUserById_ShouldReturnNothing_WhenCustomerDoesNotExist()
        ***REMOVED***
            // Arrange
            
            _efRepositoryMock.Setup(x => x.GetByIdAsync<User>(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var user = _sut.GetUserById(new Random().Next());

            // Assert
            Assert.Null(user);

       ***REMOVED***

        [Fact]
        public async Task AddUser_ShouldReturnUserDto()
        ***REMOVED***
            // Arrange

            var userMock = new UserDto
            ***REMOVED***
                Id = new Random().Next(),
                Username = "",
                Password = "",
                FirstName = "",
                LastName = "",
                UserRole = ""
           ***REMOVED***;

            // Act
            var user = _sut.AddUser(userMock);

            // Assert
            Assert.Equal(user, userMock);
       ***REMOVED***

        [Fact]
        async Task DeleteUser_ShouldReturnNothing()
        ***REMOVED***
            int userId = new Random().Next();
            // Arrange
            var userMock = new User
            ***REMOVED***
                Id = userId,
                Username = "",
                Password = "",
                FirstName = "",
                LastName = "",
                UserRole = ""
           ***REMOVED***;

            // Assert
            Assert.Equal(userMock.Id, userId);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
