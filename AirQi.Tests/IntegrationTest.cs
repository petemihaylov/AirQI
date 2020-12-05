using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AirQi.Tests
***REMOVED***
    public class IntegrationTest 
    ***REMOVED***
        protected readonly HttpClient _client;
        
        public IntegrationTest()
        ***REMOVED***
            var appFactory = WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
       ***REMOVED***
   ***REMOVED***
***REMOVED***