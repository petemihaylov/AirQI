using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AirQi.Services
{
    public abstract class WorkerService : IWorkerService
    {
        private IMongoDataRepository<Station> _repository;

        public WorkerService(IMongoDataRepository<Station> repository)
        {
            this.Repository = repository;
        }

        protected IMongoDataRepository<Station> Repository { get => _repository; set => _repository = value; }

        public abstract Task PullDataAsync();
    }
}