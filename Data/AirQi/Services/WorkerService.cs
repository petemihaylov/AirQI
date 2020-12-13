using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Settings;
using Microsoft.AspNetCore.SignalR;
using AssetNXT.Hubs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AutoMapper;
using AirQi.Dtos;

namespace AirQi.Services
***REMOVED***
    public class WorkerService : IWorkerService
    ***REMOVED***
        private IMongoDataRepository<Station> _repository;
        private IHubContext<StationHub<StationReadDto>> _hub;
        private IWorkerSettings _settings;
        private IMapper _mapper;

        public WorkerService(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub<StationReadDto>> hub, IMapper mapper)
        ***REMOVED***
            this.Hub = hub;
            this.Mapper = mapper;
            this.Repository = repository;
            this.Settings = settings;
       ***REMOVED***

        public IWorkerSettings Settings ***REMOVED*** get => _settings; set => _settings = value;***REMOVED***
        public IMapper Mapper ***REMOVED*** get => _mapper; set => _mapper = value;***REMOVED***
        protected IMongoDataRepository<Station> Repository ***REMOVED*** get => _repository; set => _repository = value;***REMOVED***
        protected IHubContext<StationHub<StationReadDto>> Hub ***REMOVED*** get => _hub; set => _hub = value;***REMOVED***


        public virtual async Task PullDataAsync()
        ***REMOVED***
            var stations =  await _repository.GetAllLatestAsync();

            IEnumerable<StationReadDto> stationDtos = Mapper.Map<IEnumerable<StationReadDto>>(stations);
          
            // SignalR event
            await _hub.Clients.All.SendAsync("GetNewStations", stations);
            Console.WriteLine("Trigger Websocket");

       ***REMOVED***
        
   ***REMOVED***
***REMOVED***