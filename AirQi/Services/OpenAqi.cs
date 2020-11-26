using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AirQi
{
    public class OpenAqi 
    {
        private HttpClient _client = new HttpClient();
        private string url = "https://api.openaq.org/v1/latest";

        public void ExecuteWorker()
        {
            throw new System.NotImplementedException();
        }

        public async Task ExecuteWorkerAsync()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(responseBody);

                
            }
            else
            {
                Console.WriteLine("The website is down. Status code {StatusCode}", response.StatusCode);
            }
        }
    }
}