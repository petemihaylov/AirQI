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
    public class PullSmartCitizen : WorkerService
    ***REMOVED***
        private HttpClient _client;
        private string url = "https://api.smartcitizen.me/v0/devices/world_map";
        public PullSmartCitizen(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub> hub, IMapper mapper) : base(repository, settings, hub, mapper)
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
            HttpResponseMessage response = await Client.GetAsync(url);

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.SerializeObject(responseBody);
            

       ***REMOVED***
        
   ***REMOVED***
***REMOVED***