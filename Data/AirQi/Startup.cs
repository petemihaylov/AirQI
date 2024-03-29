using Hangfire;
using AutoMapper;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using AirQi.Settings;
using AirQi.Services.RecurringJobs;
using AirQi.Services.RecurringJobs.Core;
using AirQi.Repository.Core;
using AirQi.Hubs;

namespace AirQi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurations
            ConfigureDatabaseServices(services);
            ConfigureHangfireServices(services);
            ConfigureSwaggerServices(services);

            // Scopes
            services.AddTransient(typeof(IMongoDataRepository<>), typeof(MongoDataRepository<>)); // A reference to multiple instances
            services.AddTransient<IWorkerService, WorkerService>();

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Controllers Serialization
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // SignalR
            ConfigureCrossOriginResourceSharing(services);
            services.AddSignalR();

        }

        // MongoDB Configurations
        public void ConfigureDatabaseServices(IServiceCollection services)
        {
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }

        // Swagger Configurations
        public void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
            });
        }

        // SignalR Configurations
        public void ConfigureCrossOriginResourceSharing(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CrosPolicy", policy =>
                {

                    policy.SetIsOriginAllowed(origin => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        // Hangfire
        public void ConfigureHangfireServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage()
            );

            services.AddHangfireServer();

            // Worker Settings Configurations
            services.Configure<WorkerSettings>(Configuration.GetSection(nameof(WorkerSettings)));
            services.AddSingleton<IWorkerSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<WorkerSettings>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // SignalR
            app.UseCors("CrosPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LiveStationHub>("/livestations");
                endpoints.MapHub<LiveNotificationHub>("/livenotifications");
            });

            // Swagger config
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            // Hangfire
            app.UseHangfireDashboard();

            // ****************************** hangfire background jobs ******************************

            // this job will trigger the SignalR Hub connection to the Client every hour
            RecurringJob.AddOrUpdate<WorkerService>("Websocket", service => service.PullDataAsync(), Cron.Hourly);
            
            // this job will fetch global data from OpenAqi every minute
            RecurringJob.AddOrUpdate<PullOpenAqi>("Open-Aqi", service => service.PullDataAsync() , Cron.Hourly);

            // this job will fetch world data from Aqicn once every day
            RecurringJob.AddOrUpdate<PullAqicn>("Aqicn", service => service.PullDataAsync() , Cron.Daily);

            // this job will fetch data from SmartCitizen at every 2nd minute
            RecurringJob.AddOrUpdate<PullSmartCitizen>("Smart-Citizen", service => service.PullDataAsync() , "*/2 * * * *");

            // this job will fetch data from AirThings at every 30 minutes
            RecurringJob.AddOrUpdate<PullAirThings>("Air-Things", service => service.PullDataAsync() , "*/30 * * * *");
        }
    }
}
