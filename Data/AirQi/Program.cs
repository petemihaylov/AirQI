using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AirQi
***REMOVED***
    public class Program
    ***REMOVED***
        public static void Main(string[] args)
        ***REMOVED***
            CreateHostBuilder(args).Build().Run();
       ***REMOVED***

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                ***REMOVED***
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:9000/");
               ***REMOVED***);
   ***REMOVED***
***REMOVED***
