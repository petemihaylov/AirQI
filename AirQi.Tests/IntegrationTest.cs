using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AirQi.Tests
{
    public class IntegrationTest 
    {
        protected readonly HttpClient _client;
        
        public IntegrationTest()
        {
            var appFactory = WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }
    }
}