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
            ConfigureSwaggerServices(services);
            ConfigureDatabaseServices(services);
            ConfiguraHangfireServices(services);
            ConfigureCrossOriginResourceSharing(services);
            

            // Scope
            services.AddScoped(typeof(IMongoDataRepository<>), typeof(MongoDataRepository<>));

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Controllers Serialization
            services.AddControllers().AddNewtonsoftJson(options =>
            ***REMOVED***
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           ***REMOVED***);

            // SignalR
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
                options.AddPolicy("ClientPermission", policy =>
                ***REMOVED***
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
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

            services.AddSingleton<IRecurringJobs, RecurringJobs>();
       ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        ***REMOVED***
            if (env.IsDevelopment())
            ***REMOVED***
                app.UseDeveloperExceptionPage();
           ***REMOVED***

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            ***REMOVED***
                endpoints.MapControllers();
           ***REMOVED***);

            // Swagger config
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            ***REMOVED***
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
           ***REMOVED***);

            // SignalR
            app.UseCors("ClientPermission");

            // Hangfire
            app.UseHangfireDashboard();

            // ****************************** hangfire background jobs ******************************

            // this job will fetch new data for Bulgaria from AirThings every minute
            // RecurringJob.AddOrUpdate<IRecurringJob>("AirThings", x => x.ExecuteWorkerAsync() , Cron.Minutely);

            // this job will fetch global data from OpenAqi every minute
            RecurringJob.AddOrUpdate<IRecurringJobs>("OpenAqi", x => x.PullOpenAqiDataAsync() , Cron.Minutely);

       ***REMOVED***
   ***REMOVED***
***REMOVED***
