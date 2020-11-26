using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AirQi
***REMOVED***
    public class RecurringJobs : IRecurringJobs
    ***REMOVED***
        private HttpClient _client = new HttpClient();
        private string url = "https://api.openaq.org/v1/latest";

        public async Task PullOpenAqiDataAsync()
        ***REMOVED***
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            ***REMOVED***
                Console.WriteLine(responseBody);
           ***REMOVED***
            else
            ***REMOVED***
                Console.WriteLine("The website is down. Status code ***REMOVED***StatusCode***REMOVED***", response.StatusCode);
           ***REMOVED***
       ***REMOVED***
   ***REMOVED***
***REMOVED***