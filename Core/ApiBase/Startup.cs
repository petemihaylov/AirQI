using System;
using AutoMapper;
using ApiBase.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiBase.Models;
using ApiBase.Hubs;
using ApiBase.Services.Interfaces;
using ApiBase.Services;

namespace ApiBase
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
            services.AddCors(options =>
            ***REMOVED***
                options.AddPolicy("ClientPermission", policy =>
                ***REMOVED***
                    policy.SetIsOriginAllowed(origin => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
               ***REMOVED***);
           ***REMOVED***);



            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("AzureConnection")));


            services.AddScoped<IEFRepository, SqlRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // Register the JwtBearer Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            ***REMOVED***
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                ***REMOVED***
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        Configuration["Jwt:Key"]))

               ***REMOVED***;
           ***REMOVED***);

            services.AddAuthorization(config =>
            ***REMOVED***
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
           ***REMOVED***);

            services.AddSignalR();
       ***REMOVED***

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        ***REMOVED***

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            ***REMOVED***
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
           ***REMOVED***);
            app.UseRouting();


            // Enable CORS policies            
            app.UseCors("ClientPermission");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            ***REMOVED***
                endpoints.MapControllers();
                endpoints.MapHub<LiveNotificationHub>("/livenotification");
                endpoints.MapHub<LiveMarkerHub>("/livemarker");
           ***REMOVED***);

       ***REMOVED***
   ***REMOVED***
***REMOVED***
