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
{
    public class UserServiceTests
    {

        private readonly UserService _sut;
        private readonly  Mock<IEFRepository> _efRepositoryMock = new Mock<IEFRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public UserServiceTests()
        {
            _sut = new UserService(_efRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenCustomerExists()
        {
            // Arrange
            var userId = new Random().Next();

            var userMock = new User
            {
                Id = userId,
                Username = "username",
                Password = "password",
                FirstName = "",
                LastName = "",
                UserRole = "User"
            };

           _efRepositoryMock.Setup(x => x.GetByIdAsync<User>(userId))
                .ReturnsAsync(userMock);

            // Act
            var user = _sut.GetUserById(userId);

            // Assert
            Assert.Equal(user.Id, userId);

        }


        [Fact]
        public async Task GetUserById_ShouldReturnNothing_WhenCustomerDoesNotExist()
        {
            // Arrange
            
            _efRepositoryMock.Setup(x => x.GetByIdAsync<User>(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var user = _sut.GetUserById(new Random().Next());

            // Assert
            Assert.Null(user);

        }

        [Fact]
        public async Task AddUser_ShouldReturnUserDto()
        {
            // Arrange

            var userMock = new UserDto
            {
                Id = new Random().Next(),
                Username = "",
                Password = "",
                FirstName = "",
                LastName = "",
                UserRole = ""
            };

            // Act
            var user = _sut.AddUser(userMock);

            // Assert
            Assert.Equal(user, userMock);
        }

        [Fact]
        async Task DeleteUser_ShouldReturnNothing()
        {
            int userId = new Random().Next();
            // Arrange
            var userMock = new User
            {
                Id = userId,
                Username = "",
                Password = "",
                FirstName = "",
                LastName = "",
                UserRole = ""
            };

            // Assert
            Assert.Equal(userMock.Id, userId);
        }
    }
}
