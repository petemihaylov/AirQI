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
{
    public class WorkerService : IWorkerService
    {
        private IMongoDataRepository<Station> _repository;
        private IHubContext<StationHub<StationReadDto>> _hub;
        private IWorkerSettings _settings;
        private IMapper _mapper;

        public WorkerService(IMongoDataRepository<Station> repository, IWorkerSettings settings, IHubContext<StationHub<StationReadDto>> hub, IMapper mapper)
        {
            this.Hub = hub;
            this.Mapper = mapper;
            this.Repository = repository;
            this.Settings = settings;
        }

        public IWorkerSettings Settings { get => _settings; set => _settings = value; }
        public IMapper Mapper { get => _mapper; set => _mapper = value; }
        protected IMongoDataRepository<Station> Repository { get => _repository; set => _repository = value; }
        protected IHubContext<StationHub<StationReadDto>> Hub { get => _hub; set => _hub = value; }


        public virtual async Task PullDataAsync()
        {
            var stations =  await _repository.GetAllLatestAsync();

            IEnumerable<StationReadDto> stationDtos = Mapper.Map<IEnumerable<StationReadDto>>(stations);
          
            // SignalR event
            await _hub.Clients.All.SendAsync("GetNewStations", stations);
            Console.WriteLine("Trigger Websocket");

        }
        
    }
}