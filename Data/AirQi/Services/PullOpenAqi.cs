using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;


namespace AirQi
***REMOVED***
    public class PullOpenAqi : WorkerService
    ***REMOVED***
        private HttpClient _client;
        public PullOpenAqi(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub> hub, IMapper mapper) : base(repository, settings, hub, mapper)
        ***REMOVED***
            this.Hub = base.Hub;
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

            HttpResponseMessage response = await Client.GetAsync("https://api.openaq.org/v1/latest");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            
            dynamic json = JsonConvert.DeserializeObject(result);
            
            foreach (var s in json.results)
            ***REMOVED***

                if (s.coordinates != null)
                ***REMOVED***
                
                Station station = new Station();
                station.Location = s.location.ToString();
                station.City = s.city.ToString();
                station.Country = s.country.ToString();
                
                
                var latitude = Convert.ToDouble(s.coordinates.latitude);
                var longitude = Convert.ToDouble(s.coordinates.longitude);
                double[] position = new double[] ***REMOVED*** longitude, latitude***REMOVED***;

                station.Position = position;
                
                station.CreatedAt = DateTime.UtcNow;
                station.UpdatedAt = DateTime.UtcNow;
                station.Aqi = 0;

                    List<Measurement> measurementsCollection = new List<Measurement>();

                    foreach(var m in s.measurements)
                    ***REMOVED***
                        Measurement measurement = new Measurement();
                        measurement.Parameter = Convert.ToString(m.parameter);
                        measurement.Value = Convert.ToDouble(m.value);
                        measurement.LastUpdated = Convert.ToString(m.lastUpdated);
                        measurement.Unit = Convert.ToString(m.unit);
                        measurement.SourceName = Convert.ToString(m.sourceName);

                        if(Convert.ToString(m.parameter) == "pm10")
                        ***REMOVED***
                            station.Aqi = Convert.ToDouble(m.value);
                       ***REMOVED*** 
                        else if(Convert.ToString(m.parameter) == "pm25" && station.Aqi == 0)
                        ***REMOVED***
                            station.Aqi = Convert.ToDouble(m.value);
                       ***REMOVED***

                        measurementsCollection.Add(measurement);
                   ***REMOVED***

                    station.Measurements = measurementsCollection;
                    
                    // Save the new Station in the repository only when there is a location
                    System.Console.WriteLine($"OpenAqi saved ***REMOVED***station.Location***REMOVED*** station in ***REMOVED***station.City***REMOVED***, ***REMOVED***station.Country***REMOVED***");
                    await Repository.CreateObjectAsync(station);
               ***REMOVED***

           ***REMOVED***
           
       ***REMOVED***
   ***REMOVED***
***REMOVED***