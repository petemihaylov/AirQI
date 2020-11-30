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
***REMOVED***
    public abstract class WorkerService : IWorkerService
    ***REMOVED***
        private IMongoDataRepository<Station> _repository;

        public WorkerService(IMongoDataRepository<Station> repository)
        ***REMOVED***
            this.Repository = repository;
       ***REMOVED***

        protected IMongoDataRepository<Station> Repository ***REMOVED*** get => _repository; set => _repository = value;***REMOVED***

        public abstract Task PullDataAsync();
   ***REMOVED***
***REMOVED***