using System.Threading.Tasks;

namespace ApiHelper
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string uri);
        Task<T> PostAsJsonAsync<T, TU>(string uri, TU data);
        Task PostAsJsonAsync<T>(string uri, T data);
        Task PutAsJsonAsync<T>(string uri, T data);
    }
}
