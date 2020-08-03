using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string uri, T data);
        Task<HttpResponseMessage> PutAsJsonAsync<T>(string uri, T data);
    }
}
