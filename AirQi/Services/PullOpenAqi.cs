using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirQi
{
    public class PullOpenAqi : WorkerService
    {
        private HttpClient _client;
        public PullOpenAqi(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
        {
            this.Repository = repository;
            this.Settings = settings;
            this.Client = new HttpClient();
        }

        public HttpClient Client { get => _client; set => _client = value; }

        public override async Task PullDataAsync()
        {
            // Gets headers which should be sent in each request.
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.GetAsync("https://api.openaq.org/v1/latest");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            
            dynamic json = JsonConvert.DeserializeObject(result);
            
            foreach (var s in json.results)
            {
                Station station = new Station();
                station.Location = s.location.ToString();
                station.City = s.city.ToString();
                station.Country = s.country.ToString();

                List<Measurement> measurementsCollection = new List<Measurement>();

                foreach(var m in s.measurements)
                {
                    Measurement measurement = new Measurement();
                    measurement.Parameter = m.parameter.ToString();
                    measurement.Value = double.Parse(m.value);
                    measurement.LastUpdated = DateTime.Parse(m.lastUpdated);
                    measurement.Unit = m.unit.ToString();
                    measurement.SourceName = m.sourceName.ToString();

                    measurementsCollection.Add(measurement);
                }

                station.Measurements = measurementsCollection;

                if (s.coordinates != null)
                {
                    Coordinates coordinates = new Coordinates();
                    coordinates.Latitude = double.Parse(s.coordinates.latitude);
                    coordinates.Longitude = double.Parse(s.coordinates.longitude);

                    station.Coordinates = coordinates;
                    station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                    
                    // Save the new Station in the repository only when there is a location
                    System.Console.WriteLine($"OpenAqi saved {station.Location} station in {station.City}, {station.Country}");
                    Repository.CreateObject(station);
                }

            }
           
        }
    }
}