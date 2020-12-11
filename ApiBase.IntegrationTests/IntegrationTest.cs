﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiBase.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace ApiBase.IntegrationTests
***REMOVED***
    public class IntegrationTest
    ***REMOVED***
        protected readonly HttpClient TestClient;
        protected IntegrationTest()
        ***REMOVED***

            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                ***REMOVED***
                    builder.ConfigureServices(services =>
                    ***REMOVED***
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                 typeof(DbContextOptions<ApplicationContext>));

                        services.Remove(descriptor);
                        services.AddDbContext<ApplicationContext>((options, context) =>
                        ***REMOVED***
                            context.UseSqlServer("Server=tcp:airqi.database.windows.net,1433;Initial Catalog=testairdb;Persist Security Info=False;User ID=airqi;Password=Qazwsx098;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                       ***REMOVED***);

                        var sp = services.BuildServiceProvider();
                        using (var scope = sp.CreateScope())
                        ***REMOVED***
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<ApplicationContext>();
                            db.Database.EnsureCreated();
                       ***REMOVED***

                   ***REMOVED***);
               ***REMOVED***);
            TestClient = appFactory.CreateClient();
       ***REMOVED***

        protected async Task AuthenticateAsync()
        ***REMOVED***
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBdXRoZW50aWNhdGlvblNlcnZlciIsImp0aSI6ImQ4NzkwYjdjLTliZjctNGIxYy1iZGExLTJhOTkyYWZkZTk3ZCIsImlhdCI6IjEyLzA2LzIwMjAgMjM6MDQ6MzUiLCJJZCI6IjE2IiwiVXNlcm5hbWUiOiJ0ZXN0IiwiRmlyc3ROYW1lIjoiVGVzdCIsIkxhc3ROYW1lIjoiVXNlciIsIlVzZXJSb2xlIjoiVXNlciIsImV4cCI6MTYwNzM4MjI3NSwiaXNzIjoiQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJBdXRoZW50aWNhdGlvblNlcnZlciJ9.qdqjH6fq1TgURaKS2gik3Yf03OOBymcOln3Y9ig9eO0");
       ***REMOVED***
   ***REMOVED***
***REMOVED***