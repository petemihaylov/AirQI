using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirQi
{
    public class PullAqicn : WorkerService
    {
        private HttpClient _client;
        public PullAqicn(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
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

            HttpResponseMessage response = await Client.GetAsync("https://countriesnow.space/api/v0.1/countries/");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            JObject countries = JObject.Parse(result);

            foreach(JObject country in countries.SelectToken("data"))
            {
                foreach (string city in country.SelectToken("cities"))
                {
                    await SetStation(city.ToLower(), country.SelectToken("country").Value<string>());
                }
            }

           
           
        }

        public async Task SetStation(string city, string country)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://api.waqi.info/feed/{city}/?token={this.Settings.AqicnSubscriptionKey}");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(result);

            if(json.status.ToString() == "ok")
            {
                var data = json.data;

                
                Station station = new Station();
                station.Location = data.city.name.ToString();
                station.City = data.city.name.ToString();
                station.Country = country;

                var measurements = json.data.iaqi;

                List<Measurement> measurementsCollection = new List<Measurement>();

                foreach(var m in measurements)
                {
                    System.Console.WriteLine(m.v);
                    Measurement measurement = new Measurement();
                    measurement.Parameter = m.ToString();
                    measurement.Value = double.Parse(m.v);
                    measurement.LastUpdated = DateTime.Parse(data.time.iso);
                    measurement.Unit = "µg/m³";
                    measurement.SourceName = data.attributions.name.ToString();

                    measurementsCollection.Add(measurement);
                }

                station.Measurements = measurementsCollection;

                Coordinates coordinates = new Coordinates();
                coordinates.Latitude = double.Parse(data.city.geo.First());
                coordinates.Longitude = double.Parse(data.city.geo.Last());

                station.Coordinates = coordinates;
                station.CreatedAt = DateTime.Parse(data.time.iso);
                station.UpdatedAt = DateTime.UtcNow;

                // Save the new Station in the repository only when there is a location
                System.Console.WriteLine($"Aqicn saved {station.Location} station in {station.City}, {station.Country}");
                // Repository.CreateObject(station);
            }
        }
    }
}