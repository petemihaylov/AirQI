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
***REMOVED***
    public class WorkerService : IWorkerService
    ***REMOVED***
        private IMongoDataRepository<Station> _repository;
        private IWorkerSettings _settings;

        public WorkerService(IMongoDataRepository<Station> repository, IWorkerSettings settings)
        ***REMOVED***
            this.Repository = repository;
            this.Settings = settings;
       ***REMOVED***

        public IWorkerSettings Settings ***REMOVED*** get => _settings; set => _settings = value;***REMOVED***
        protected IMongoDataRepository<Station> Repository ***REMOVED*** get => _repository; set => _repository = value;***REMOVED***

        public virtual Task PullDataAsync()
        ***REMOVED***
            throw new NotImplementedException();
       ***REMOVED***
        
   ***REMOVED***
***REMOVED***