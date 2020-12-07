using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using System.Threading.Tasks;
using ApiBase.Models;
using Xunit;

namespace ApiBase.IntegrationTests
***REMOVED***
    public class UserControllerTest : IntegrationTest
    ***REMOVED***
        [Fact]
        public async Task GetAllUsers_WithoutAnyUsers_ReturnsEmptyResponse()
        ***REMOVED***

            // Arrange
            await AuthenticateAsync();
            var list = new List<User>() ***REMOVED*** new User() ***REMOVED*** Id = 1, FirstName = "Test", LastName = "User", Password = "test", UserRole = "User", Username = "test"***REMOVED******REMOVED***;


            // Act
            var response = await  TestClient.GetAsync("/api/users");

            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<User>>()).ShouldAllBeEquivalentTo(list);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
