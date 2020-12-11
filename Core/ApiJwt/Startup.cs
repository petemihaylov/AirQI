using ApiJwt.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiJwt
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
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
               ***REMOVED***);
           ***REMOVED***);

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("ApiConnection")));

            services.AddScoped<IEFRepository, SqlRepository>();


            services.AddCors();
            services.AddControllers();
       ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        ***REMOVED***

            if (env.IsDevelopment())
            ***REMOVED***
                app.UseDeveloperExceptionPage();
           ***REMOVED***

            // Enable CORS policies            
            app.UseCors("ClientPermission");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            ***REMOVED***
                endpoints.MapControllers();
           ***REMOVED***);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
