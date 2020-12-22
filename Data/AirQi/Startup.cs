using System;
using Hangfire;
using AutoMapper;
using AirQi.Settings;
using AirQi.Services;
using AirQi.Repository;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using AssetNXT.Hubs;
using AirQi.Models.Core;
using Hangfire.Server;

namespace AirQi
***REMOVED***
    public class Startup
    ***REMOVED***
        public Startup(IConfiguration configuration)
        ***REMOVED***
            Configuration = configuration;
       ***REMOVED***

        public IConfiguration Configuration ***REMOVED*** get;***REMOVED***

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        ***REMOVED***
            // Configurations
            ConfigureDatabaseServices(services);
            ConfiguraHangfireServices(services);
            ConfigureSwaggerServices(services);

            // Scopes
            services.AddTransient(typeof(IMongoDataRepository<>), typeof(MongoDataRepository<>)); // A refference to mutiple instances
            services.AddTransient<IWorkerService, WorkerService>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Controllers Serialization
            services.AddControllers().AddNewtonsoftJson(options =>
            ***REMOVED***
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           ***REMOVED***);

            // SignalR
            ConfigureCrossOriginResourceSharing(services);
            services.AddSignalR();
       ***REMOVED***

        // MongoDB Configurations
        public void ConfigureDatabaseServices(IServiceCollection services)
        ***REMOVED***
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
       ***REMOVED***

        // Swagger Configurations
        public void ConfigureSwaggerServices(IServiceCollection services)
        ***REMOVED***
            services.AddSwaggerGen(options =>
            ***REMOVED***
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                ***REMOVED***
                    Title = "API",
                    Version = "v1"
               ***REMOVED***);
           ***REMOVED***);
       ***REMOVED***

        // SignalR Configurations
        public void ConfigureCrossOriginResourceSharing(IServiceCollection services)
        ***REMOVED***
            services.AddCors(options =>
            ***REMOVED***
                options.AddPolicy("CrosPolicy", policy =>
                ***REMOVED***

                    policy.SetIsOriginAllowed(origin => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
               ***REMOVED***);
           ***REMOVED***);
       ***REMOVED***

        // Hangfire
        public void ConfiguraHangfireServices(IServiceCollection services)
        ***REMOVED***
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
       ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        ***REMOVED***
            if (env.IsDevelopment())
            ***REMOVED***
                app.UseDeveloperExceptionPage();
           ***REMOVED***

            // SignalR
            app.UseCors("CrosPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            ***REMOVED***
                endpoints.MapControllers();
                endpoints.MapHub<StationHub>("/livestations");
           ***REMOVED***);

            // Swagger config
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            ***REMOVED***
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
           ***REMOVED***);

            // Hangfire
            app.UseHangfireDashboard();

            // ****************************** hangfire background jobs ******************************

            // this job will trigger the SignalR Hub connection to the Client every hour
            RecurringJob.AddOrUpdate<WorkerService>("Websocket", service => service.PullDataAsync() , Cron.Hourly);

            // this job will fetch global data from OpenAqi every minute
            // RecurringJob.AddOrUpdate<PullOpenAqi>("Open-Aqi", service => service.PullDataAsync() , Cron.Hourly);

            // this job will fetch world data from Aqicn once every day
            // RecurringJob.AddOrUpdate<PullAqicn>("Aqicn", service => service.PullDataAsync() , Cron.Daily);

            // this job will fetch data from SmartCitizen at every 2nd minute
            // RecurringJob.AddOrUpdate<PullSmartCitizen>("Smart-Citizen", service => service.PullDataAsync() , "*/2 * * * *");

            // this job will fetch data from AirThings at every 30 minutes
            // RecurringJob.AddOrUpdate<PullAirThings>("Air-Things", service => service.PullDataAsync() , "*/30 * * * *");
       ***REMOVED***
   ***REMOVED***
***REMOVED***
