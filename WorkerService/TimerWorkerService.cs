using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
***REMOVED***
    internal sealed class TimerWorkerService : IHostedService, IDisposable
    ***REMOVED***
        private readonly ILogger<TimerWorkerService> _logger;
        private Timer _timer;

        public TimerWorkerService(ILogger<TimerWorkerService> logger)
        ***REMOVED***
            _logger = logger;
       ***REMOVED***

        public Task StartAsync(CancellationToken cancellationToken)
        ***REMOVED***
            _timer = new Timer(OnTimer, cancellationToken, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
       ***REMOVED***

        private void OnTimer(object state)
        ***REMOVED***
            _logger.LogInformation("OnTimer event called");
       ***REMOVED***

        public Task StopAsync(CancellationToken cancellationToken)
        ***REMOVED***
            _logger.LogInformation("StopAsync Called");
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
       ***REMOVED***

        public void Dispose()
        ***REMOVED***
            _logger.LogInformation("Dispose Called");
            _timer?.Dispose();
       ***REMOVED***
   ***REMOVED***
***REMOVED***
