using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AirQi.Services
{
    public class WorkerService : IWorkerService
    {
        private IMongoDataRepository<Station> _repository;
        private IWorkerSettings _settings;

        public WorkerService(IMongoDataRepository<Station> repository, IWorkerSettings settings)
        {
            this.Repository = repository;
            this.Settings = settings;
        }

        public IWorkerSettings Settings { get => _settings; set => _settings = value; }
        protected IMongoDataRepository<Station> Repository { get => _repository; set => _repository = value; }

        public virtual Task PullDataAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}