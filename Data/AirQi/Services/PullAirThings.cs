using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Dtos;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using AssetNXT.Hubs;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace AirQi
{
    public class PullAirThings : WorkerService
    {
        private HttpClient _client;
        private string url = "https://airthings.azure-api.net/api/Devices";
        public PullAirThings(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub<StationReadDto>> hub, IMapper mapper) : base(repository, settings, hub, mapper)
        {
            this.Hub = hub;
            this.Mapper = mapper;
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

            HttpResponseMessage responseDevices = await Client.GetAsync(url);

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            responseDevices.EnsureSuccessStatusCode();
            string responseBodyDevices = await responseDevices.Content.ReadAsStringAsync();
            var devices = JObject.Parse(responseBodyDevices);
            // System.Console.WriteLine(devices);

            // Returns Devices Measurements
            await Task.FromResult(GetMeasurements(devices));
        }

        public async Task GetMeasurements(JObject devices)
        {
            // Iterates through all devicesIds
            foreach (var d in devices.SelectToken("devices"))
            {
                var deviceId = d.SelectToken("deviceId").Value<string>();
                
                // 429 (Too Many Requests)
                HttpResponseMessage responseMeasurements = await Client.GetAsync($"https://airthings.azure-api.net/api/Telemetry/{deviceId}/aqivalues/lasthour");

                // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
                responseMeasurements.EnsureSuccessStatusCode();
                
                string responseBodyMeasurements = await responseMeasurements.Content.ReadAsStringAsync();

                var measurements = JObject.Parse(responseBodyMeasurements);
                System.Console.WriteLine(measurements);
            }
        }
    }
}