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
***REMOVED***
    public class PullAqicn : WorkerService
    ***REMOVED***
        private HttpClient _client;
        public PullAqicn(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
        ***REMOVED***
            this.Repository = repository;
            this.Settings = settings;
            this.Client = new HttpClient();
       ***REMOVED***

        public HttpClient Client ***REMOVED*** get => _client; set => _client = value;***REMOVED***

        public override async Task PullDataAsync()
        ***REMOVED***
            // Gets headers which should be sent in each request.
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.GetAsync("https://countriesnow.space/api/v0.1/countries/");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            JObject countries = JObject.Parse(result);

            foreach(JObject country in countries.SelectToken("data"))
            ***REMOVED***
                foreach (string city in country.SelectToken("cities"))
                ***REMOVED***
                    await SetStation(city.ToLower(), country.SelectToken("country").Value<string>());
               ***REMOVED***
           ***REMOVED***

           
           
       ***REMOVED***

        public async Task SetStation(string city, string country)
        ***REMOVED***
            HttpResponseMessage response = await Client.GetAsync($"https://api.waqi.info/feed/***REMOVED***city***REMOVED***/?token=***REMOVED***this.Settings.AqicnSubscriptionKey***REMOVED***");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(result);

            if(json.status.ToString() == "ok")
            ***REMOVED***
                var data = json.data;

                
                Station station = new Station();
                station.Location = data.city.name.ToString();
                station.City = data.city.name.ToString();
                station.Country = country;

                var measurements = json.data.iaqi;

                List<Measurement> measurementsCollection = new List<Measurement>();

                foreach(var m in measurements)
                ***REMOVED***
                    System.Console.WriteLine(m.v);
                    Measurement measurement = new Measurement();
                    measurement.Parameter = m.ToString();
                    measurement.Value = double.Parse(m.v);
                    measurement.LastUpdated = DateTime.Parse(data.time.iso);
                    measurement.Unit = "µg/m³";
                    measurement.SourceName = data.attributions.name.ToString();

                    measurementsCollection.Add(measurement);
               ***REMOVED***

                station.Measurements = measurementsCollection;

                Coordinates coordinates = new Coordinates();
                coordinates.Latitude = double.Parse(data.city.geo.First());
                coordinates.Longitude = double.Parse(data.city.geo.Last());

                station.Coordinates = coordinates;
                station.CreatedAt = DateTime.Parse(data.time.iso);
                station.UpdatedAt = DateTime.UtcNow;

                // Save the new Station in the repository only when there is a location
                System.Console.WriteLine($"Aqicn saved ***REMOVED***station.Location***REMOVED*** station in ***REMOVED***station.City***REMOVED***, ***REMOVED***station.Country***REMOVED***");
                // Repository.CreateObject(station);
           ***REMOVED***
       ***REMOVED***
   ***REMOVED***
***REMOVED***