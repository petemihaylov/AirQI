using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aqi.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

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
            // DB dependencies
            services.AddDbContext<AqiDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(s => ***REMOVED***
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           ***REMOVED***);
            
            // Configure dependeces injection system
            services.AddScoped<IStationRepo, SqlStationRepo>();

            // Swagger
            services.AddSwaggerGen(options =>
            ***REMOVED***
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                ***REMOVED***
                    Title = "AQI Rest API",
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

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            ***REMOVED***
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AQI Rest API");
           ***REMOVED***);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
