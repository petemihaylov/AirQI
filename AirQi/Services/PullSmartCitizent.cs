using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using Newtonsoft.Json.Linq;

namespace AirQi
{
    public class PullSmartCitizen : WorkerService
    {
        private HttpClient _client;
        private string url = "https://api.smartcitizen.me/v0/devices";
        public PullSmartCitizen(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
        {
            this.Repository = repository;
            this.Settings = settings;
            this.Client = new HttpClient();
        }

        public HttpClient Client { get => _client; set => _client = value; }

        public override async Task PullDataAsync()
        {
            // Gets headers which should be sent in each request.
            // Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync(url);

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseBody);
            
            // System.Console.WriteLine(responseBody);
            
            // foreach (var s in json.SelectToken("results"))
            // {
            //     Station station = new Station();
            //     station.Location = s.SelectToken("location").Value<string>();
            //     station.City = s.SelectToken("city").Value<string>();
            //     station.Country = s.SelectToken("country").Value<string>();

            //     var measurements = s.SelectToken("measurements");

            //     List<Measurement> measurementsCollection = new List<Measurement>();

            //     foreach(var m in measurements)
            //     {
            //         Measurement measurement = new Measurement();
            //         measurement.Parameter = m.SelectToken("parameter").Value<string>();
            //         measurement.Value = m.SelectToken("value").Value<double>();
            //         measurement.LastUpdated = m.SelectToken("lastUpdated").Value<DateTime>();
            //         measurement.Unit = m.SelectToken("unit").Value<string>();
            //         measurement.SourceName = m.SelectToken("sourceName").Value<string>();

            //         measurementsCollection.Add(measurement);
            //     }

            //     station.Measurements = measurementsCollection;

            //     if (s.SelectToken("coordinates") != null)
            //     {
            //         Coordinates coordinates = new Coordinates();
            //         coordinates.Latitude = s.SelectToken("coordinates").SelectToken("latitude").Value<double>();
            //         coordinates.Longitude = s.SelectToken("coordinates").SelectToken("longitude").Value<double>();

            //         station.Coordinates = coordinates;
            //         station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                    
            //         // Save the new Station in the repository only when there is a location
            //         System.Console.WriteLine($"OpenAqi saved {station.Location} station in {station.City}, {station.Country}");
            //         Repository.CreateObject(station);
            //     }

            // }
           
        }
    }
}