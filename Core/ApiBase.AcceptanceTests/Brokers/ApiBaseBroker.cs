using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;

namespace ApiBase.AcceptanceTests.Brokers
***REMOVED***
    public partial class ApiBaseBroker
    ***REMOVED***
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public ApiBaseBroker()
        ***REMOVED***
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.httpClient);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
