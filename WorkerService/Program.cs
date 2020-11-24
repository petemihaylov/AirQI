using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueServiceWorker;

namespace WorkerService
***REMOVED***
    public class Program
    ***REMOVED***
        public static void Main(string[] args)
        ***REMOVED***
            CreateHostBuilder(args).Build().Run();
       ***REMOVED***

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                ***REMOVED***
                    services.AddHostedService<WorkerAirThings>();
                    services.AddHostedService<QueueService>();
               ***REMOVED***);
   ***REMOVED***
***REMOVED***
