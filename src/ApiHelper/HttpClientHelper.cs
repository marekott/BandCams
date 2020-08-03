using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private HttpClient _httpClient;

        public HttpClientHelper(string serviceUrl, string subscriptionKey)
        {
            InitializeClient(serviceUrl, subscriptionKey);
        }

        private void InitializeClient(string serviceUrl, string subscriptionKey)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(serviceUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await _httpClient.GetAsync(uri);
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string uri, T data)
        {
            return await _httpClient.PostAsJsonAsync(uri, data);
        }

        public async Task<HttpResponseMessage> PutAsJsonAsync<T>(string uri, T data)
        {
            return await _httpClient.PutAsJsonAsync(uri, data);
        }
    }
}
