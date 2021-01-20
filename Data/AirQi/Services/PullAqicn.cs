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
using AirQi.Repository.Core;
using AirQi.Services;
using AirQi.Settings;
using Microsoft.CSharp.RuntimeBinder;
using AssetNXT.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using AirQi.Dtos;

namespace AirQi
{
    public class PullAqicn : WorkerService
    {
        private HttpClient _client;
        public PullAqicn(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<LiveStationHub> hub, IMapper mapper) : base(repository, settings, hub, mapper)
        {
            this.Hub = base.Hub;
            this.Mapper = mapper;
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

                string aqi = data.aqi.ToString();
                station.Aqi = aqi.Contains("-") ? 0 : double.Parse(aqi);

                           
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                
                var latitude = Convert.ToDouble(data.city.geo[0], provider);
                var longitude = Convert.ToDouble(data.city.geo[1], provider);
                double[] position = new double[] { longitude, latitude };

                station.Position = position;
                station.CreatedAt = DateTime.UtcNow;
                station.UpdatedAt = DateTime.UtcNow;

                // Measurements
                List<Measurement> measurementsCollection = new List<Measurement>();

                var measurements = data.iaqi;

                foreach (var m in measurements)
                {
                    Measurement measurement = new Measurement();
                    measurement.LastUpdated = Convert.ToString(data.time.iso);
                    measurement.Unit = "µg/m³";

                    measurement.SourceName = Convert.ToString(data.attributions[0].name);

                    string obj = GetType(m);

                    measurement.Parameter = obj;
                    measurement.Value = Convert.ToDouble(measurements[obj].v);
                
                    measurementsCollection.Add(measurement);
                }

                station.Measurements = measurementsCollection;

                // Save the new Station in the repository only when there is a location
                System.Console.WriteLine($"Aqicn saved {station.Location} station in {station.City}, {station.Country}");
                await Repository.CreateObjectAsync(station);
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