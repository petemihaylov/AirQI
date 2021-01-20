using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApiBase
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
                    webBuilder.UseUrls("http://localhost:8080/");
               ***REMOVED***);
   ***REMOVED***
***REMOVED***
