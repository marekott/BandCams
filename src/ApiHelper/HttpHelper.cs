using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public HttpHelper(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            using var response = await _httpClientHelper.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase); //TODO customowa klasa wyjątku, która przechowuje stack trace + kod odpowiedzi?
            }
        }

        public async Task<T> PostAsJsonAsync<T, TU>(string uri, TU data)
        {
            using var response = await _httpClientHelper.PostAsJsonAsync(uri, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task PostAsJsonAsync<T>(string uri, T data)
        {
            using var response = await _httpClientHelper.PostAsJsonAsync(uri, data);
            if (response.IsSuccessStatusCode == false)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task PutAsJsonAsync<T>(string uri, T data)
        {
            using var response = await _httpClientHelper.PutAsJsonAsync(uri, data);
            if (response.IsSuccessStatusCode == false)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
