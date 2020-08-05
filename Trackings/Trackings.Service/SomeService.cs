using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trackings.Service
{
    public class SomeService : ISomeService
    {
        private readonly HttpClient _httpClient;

        public SomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<dynamic> GetAllAsync()
        {
            var data = await _httpClient.GetStringAsync("http://localhost:59053/areas");

            var basket = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<dynamic>(data) : null;

            return basket;
        }
    }
    public interface ISomeService
    {
        Task<dynamic> GetAllAsync();
    }
}
