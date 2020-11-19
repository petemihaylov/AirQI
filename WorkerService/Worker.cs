using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        public static string url;
        private readonly ILogger<Worker> _logger;
        private HttpClient _client;

        public Worker(ILogger<Worker> logger)
        {
            this._logger = logger;
            url = "https://airthings.azure-api.net/api/Devices";
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "94fceb37077f44eb8cefa7d9fe6a4d1e");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("The webiste is up. Status code {StatusCode}", response.StatusCode);
                    _logger.LogInformation(responseBody);
                }
                else
                {
                    _logger.LogError("The website is down. Status code {StatusCode}", response.StatusCode);
                }

                await Task.Delay(60 * 1000, stoppingToken);
            }
        }
    }
}
