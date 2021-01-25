using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace AirQi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opts =>
                    {
                        opts.ListenLocalhost(9000, opts => opts.UseHttps());
                        opts.ListenLocalhost(9001, opts => opts.UseHttps());
                        opts.Listen(IPAddress.Loopback, port: 9002);
                        opts.ListenAnyIP(9003);
                    });
                });
    }
}
