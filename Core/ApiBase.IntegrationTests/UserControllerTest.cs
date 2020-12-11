using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using System.Threading.Tasks;
using ApiBase.Models;
using Xunit;

namespace ApiBase.IntegrationTests
{
    public class UserControllerTest : IntegrationTest
    {
        [Fact]
        public async Task GetAllUsers_WithOneUser_ReturnsCollectionUsers()
        {

            // Arrange
            await AuthenticateAsync();
            var list = new List<User>() { new User() { Id = 1, FirstName = "Test", LastName = "User", Password = "test", UserRole = "User", Username = "test" } };


            // Act
            var response = await  TestClient.GetAsync("/api/users");

            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<User>>()).ShouldAllBeEquivalentTo(list);
        }

        [Fact]
        public async Task GetUserById_WithId_ReturnsUser()
        {

            // Arrange
            await AuthenticateAsync();
            var user = new User()
            {
                Id = 1, FirstName = "Test", LastName = "User", Password = "test", UserRole = "User", Username = "test"
            };


            // Act
            var response = await TestClient.GetAsync("/api/users/1");


            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<User>()).ShouldBeEquivalentTo(user);
        }
    }
}
