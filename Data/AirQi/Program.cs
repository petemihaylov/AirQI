using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

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
                    webBuilder.UseKestrel(opts =>
                    ***REMOVED***
                        opts.ListenLocalhost(9000, opts => opts.UseHttps());
                        opts.ListenLocalhost(9001, opts => opts.UseHttps());
                        opts.Listen(IPAddress.Loopback, port: 9002);
                        opts.ListenAnyIP(9003);
                   ***REMOVED***);
               ***REMOVED***);
   ***REMOVED***
***REMOVED***
