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
***REMOVED***
    public class PullOpenAqi : WorkerService
    ***REMOVED***
        private HttpClient _client;
        public PullOpenAqi(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
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
                
                Coordinates coordinates = new Coordinates();
                coordinates.Latitude = Convert.ToDouble(s.coordinates.latitude);
                coordinates.Longitude = Convert.ToDouble(s.coordinates.longitude);
                station.Coordinates = coordinates;
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

                        measurement.Coordinates = coordinates;
                        measurement.CreatedAt = DateTime.UtcNow;
                        measurement.UpdatedAt = DateTime.UtcNow;

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