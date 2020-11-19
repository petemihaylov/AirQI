using System;
using AutoMapper;
using Aqi.Settings;
using Aqi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;

namespace Aqi
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

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Controllers Serialization
            services.AddControllers().AddNewtonsoftJson(options => ***REMOVED***
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           ***REMOVED***);

            // Configurations
            ConfigureSwaggerServices(services);
            ConfigureDatabaseServices(services);

            // Scope
            services.AddScoped(typeof(IMongoDataRepository<>), typeof(MongoDataRepository<>));

       ***REMOVED***

        public void ConfigureDatabaseServices(IServiceCollection services)
        ***REMOVED***
            // MongoDB Configuration
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
       ***REMOVED***

        public void ConfigureSwaggerServices(IServiceCollection services)
        ***REMOVED***
            // Swagger
            services.AddSwaggerGen(options =>
            ***REMOVED***
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                ***REMOVED***
                    Title = "API",
                    Version = "v1"
               ***REMOVED***);
           ***REMOVED***);
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
       ***REMOVED***
   ***REMOVED***
***REMOVED***
