using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Data;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AirQi.Services
{
    public class RecurringJobs : IRecurringJobs
    {
        private HttpClient _client = new HttpClient();
        private string url = "https://api.openaq.org/v1/latest";

        public RecurringJobs(IMongoDataRepository<Station> repository)
        {
            
        }
        public async Task PullOpenAqiDataAsync()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //  Console.WriteLine(responseBody);

                var json = JObject.Parse(responseBody);
                
                foreach (var s in json.SelectToken("results"))
                {
                    Station station = new Station();
                    station.Location = s.SelectToken("location").Value<string>();
                    station.City = s.SelectToken("city").Value<string>();
                    station.Country = s.SelectToken("country").Value<string>();

                    var measurements = s.SelectToken("measurements");

                    List<Measurement> measurementsCollection = new List<Measurement>();

                    foreach(var m in measurements)
                    {
                        Measurement measurement = new Measurement();
                        measurement.Parameter = m.SelectToken("parameter").Value<string>();
                        measurement.Value = m.SelectToken("value").Value<double>();
                        measurement.LastUpdated = m.SelectToken("lastUpdated").Value<DateTime>();
                        measurement.Unit = m.SelectToken("unit").Value<string>();
                        measurement.SourceName = m.SelectToken("sourceName").Value<string>();

                        measurementsCollection.Add(measurement);
                    }

                    station.Measurements = measurementsCollection;

                    if (s.SelectToken("coordinates") != null)
                    {
                        Coordinates coordinates = new Coordinates();
                        coordinates.Latitude = s.SelectToken("coordinates").SelectToken("latitude").Value<double>();
                        coordinates.Longitude = s.SelectToken("coordinates").SelectToken("longitude").Value<double>();

                        station.Coordinates = coordinates;

                        Console.WriteLine($"longitude: {station.Coordinates.Longitude}, latitude: {station.Coordinates.Latitude}");
                    }

                    station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                    // _repository.CreateObject(station);
                }
            }
            else
            {
                Console.WriteLine("The website is down. Status code {StatusCode}", response.StatusCode);
            }
        }
    }
}