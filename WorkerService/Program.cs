using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                .ConfigureServices((hostContext, services) =>
                ***REMOVED***
                    services.AddHostedService<Worker>();
               ***REMOVED***);
   ***REMOVED***
***REMOVED***
