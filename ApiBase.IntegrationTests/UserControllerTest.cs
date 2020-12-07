using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FluentAssertions;
using System.Threading.Tasks;
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

            // Act
            var response = await  TestClient.GetAsync("/api/users");

            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
