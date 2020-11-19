using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
***REMOVED***
    public class Worker : BackgroundService
    ***REMOVED***
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        ***REMOVED***
            _logger = logger;
       ***REMOVED***

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        ***REMOVED***
            while (!stoppingToken.IsCancellationRequested)
            ***REMOVED***
                _logger.LogInformation("Worker running at: ***REMOVED***time***REMOVED***", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
           ***REMOVED***
       ***REMOVED***
   ***REMOVED***
***REMOVED***
