using ApiBase.Controllers;
using ApiBase.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiBase.IntegrationTests
{
    public class UsersControllerTests
    {
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_AddsUser()
        {
            // Arrange
            var user = new User { FirstName = "TestUser", Id = 2, LastName = "TestUser", Password = "12345678", RoleId = 3, UserRole = null };
            var json = JsonConvert.SerializeObject(user);

            // Act
            var response = await _client.PostAsync("/api/users", new StringContent(json, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }


        [Fact]
        public async Task GetAllUsers_ReturnsListResponses()
        {
            // Act
            var response = await _client.GetAsync("/api/users");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();

             var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
             Assert.Contains(users, p => p.FirstName == "FirstName");
        }
    }
}
