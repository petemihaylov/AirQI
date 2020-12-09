using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using Microsoft.CSharp.RuntimeBinder;
using MongoDB.Bson;
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

            if (json.status.ToString() == "ok")
            {
                var data = json.data;
                
                // Station
                Station station = new Station();
                station.Location = Convert.ToString(data.city.name);
                station.City = Convert.ToString(data.city.name);
                station.Country = country;

                Coordinates coordinates = new Coordinates();
                
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                
                coordinates.Latitude = Convert.ToDouble(data.city.geo[0], provider);
                coordinates.Longitude = Convert.ToDouble(data.city.geo[1], provider);
                station.Coordinates = coordinates;
                station.CreatedAt = DateTime.UtcNow;
                station.UpdatedAt = DateTime.UtcNow;

                // Measurements
                List<Measurement> measurementsCollection = new List<Measurement>();

                var measurements = data.iaqi;

                foreach (var m in measurements)
                {
                    Measurement measurement = new Measurement();
                    measurement.LastUpdated = DateTime.UtcNow;
                    measurement.Unit = "µg/m³";
                    
                    string aqi = data.aqi.ToString();
                    measurement.Aqi = aqi.Contains("-") ? 0 : double.Parse(aqi);

                    measurement.SourceName = Convert.ToString(data.attributions[0].name);

                    string obj = GetType(m);

                    measurement.Parameter = obj;
                    measurement.Value = Convert.ToDouble(measurements[obj].v);
                    measurement.Coordinates = coordinates;
                    measurement.CreatedAt = DateTime.UtcNow;
                    measurement.UpdatedAt = DateTime.UtcNow;
                
                    measurementsCollection.Add(measurement);
                }

                station.Measurements = measurementsCollection;

                // Save the new Station in the repository only when there is a location
                System.Console.WriteLine($"Aqicn saved {station.Location} station in {station.City}, {station.Country}");
                Repository.CreateObject(station);
            }
        }

        private static bool HasProperty(dynamic obj, string name)
        {
            try
            {
                var value = obj[name];
                return true;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }
        }

        private static string GetType(Object obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> prop = new List<PropertyInfo>(myType.GetProperties());
                   
            return prop[0].GetValue(obj, null).ToString();
        }


    }
    
}