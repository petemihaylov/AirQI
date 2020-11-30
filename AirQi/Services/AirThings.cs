using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;

namespace AirQi
{
    public class AirThings : WorkerService
    {
        private HttpClient _client;
        private string url = "https://airthings.azure-api.net/api/Devices";
        public AirThings(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
        {
            this.Repository = repository;
            this.Settings = settings;
            this.Client = new HttpClient();
        }

        public HttpClient Client { get => _client; set => _client = value; }

        public override async Task PullDataAsync()
        {
            // Gets headers which should be sent in each request.
                   
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.Settings.OcpApimSubscriptionKey);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync(url);

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();
        }
    }
}