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
using AssetNXT.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using AirQi.Dtos;

namespace AirQi
***REMOVED***
    public class PullAqicn : WorkerService
    ***REMOVED***
        private HttpClient _client;
        public PullAqicn(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub<StationReadDto>> hub, IMapper mapper) : base(repository, settings, hub, mapper)
        ***REMOVED***
            this.Hub = hub;
            this.Mapper = mapper;
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

            if (json.status.ToString() == "ok")
            ***REMOVED***
                var data = json.data;
                
                // Station
                Station station = new Station();
                station.Location = Convert.ToString(data.city.name);
                station.City = Convert.ToString(data.city.name);
                station.Country = country;

                string aqi = data.aqi.ToString();
                station.Aqi = aqi.Contains("-") ? 0 : double.Parse(aqi);

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
                ***REMOVED***
                    Measurement measurement = new Measurement();
                    measurement.LastUpdated = Convert.ToString(data.time.iso);
                    measurement.Unit = "µg/m³";

                    measurement.SourceName = Convert.ToString(data.attributions[0].name);

                    string obj = GetType(m);

                    measurement.Parameter = obj;
                    measurement.Value = Convert.ToDouble(measurements[obj].v);
                    measurement.Coordinates = coordinates;
                    measurement.CreatedAt = DateTime.UtcNow;
                    measurement.UpdatedAt = DateTime.UtcNow;
                
                    measurementsCollection.Add(measurement);
               ***REMOVED***

                station.Measurements = measurementsCollection;

                // Save the new Station in the repository only when there is a location
                System.Console.WriteLine($"Aqicn saved ***REMOVED***station.Location***REMOVED*** station in ***REMOVED***station.City***REMOVED***, ***REMOVED***station.Country***REMOVED***");
                await Repository.CreateObjectAsync(station);
           ***REMOVED***
       ***REMOVED***

        private static bool HasProperty(dynamic obj, string name)
        ***REMOVED***
            try
            ***REMOVED***
                var value = obj[name];
                return true;
           ***REMOVED***
            catch (RuntimeBinderException)
            ***REMOVED***
                return false;
           ***REMOVED***
       ***REMOVED***

        private static string GetType(Object obj)
        ***REMOVED***
            Type myType = obj.GetType();
            IList<PropertyInfo> prop = new List<PropertyInfo>(myType.GetProperties());
                   
            return prop[0].GetValue(obj, null).ToString();
       ***REMOVED***


   ***REMOVED***
    
***REMOVED***