using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
***REMOVED***
    public class WorkerAirThings : BackgroundService
    ***REMOVED***
        public static string url;
        private readonly ILogger<WorkerAirThings> _logger;
        private HttpClient _client;

        public WorkerAirThings(ILogger<WorkerAirThings> logger)
        ***REMOVED***
            this._logger = logger;
            url = "https://airthings.azure-api.net/api/Devices";
       ***REMOVED***

        public override Task StartAsync(CancellationToken cancellationToken)
        ***REMOVED***
            _client = new HttpClient();
            return base.StartAsync(cancellationToken);
       ***REMOVED***

        public override Task StopAsync(CancellationToken cancellationToken)
        ***REMOVED***
            _client.Dispose();
            return base.StopAsync(cancellationToken);
       ***REMOVED***
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        ***REMOVED***
            while (!stoppingToken.IsCancellationRequested)
            ***REMOVED***
                _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "94fceb37077f44eb8cefa7d9fe6a4d1e");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                ***REMOVED***
                    _logger.LogInformation("The webiste is up. Status code ***REMOVED***StatusCode***REMOVED***", response.StatusCode);
                    _logger.LogInformation(responseBody);
               ***REMOVED***
                else
                ***REMOVED***
                    _logger.LogError("The website is down. Status code ***REMOVED***StatusCode***REMOVED***", response.StatusCode);
               ***REMOVED***

                await Task.Delay(60 * 1000, stoppingToken);
           ***REMOVED***
       ***REMOVED***
   ***REMOVED***
***REMOVED***
