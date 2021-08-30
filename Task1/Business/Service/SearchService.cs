using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Task1.Business.Utils;
using Task1.Business.Interface;
using Task1.Business.Model;

namespace Task1.Business.Service
{
    public class SearchService :ISearchService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        private readonly RestClient<WeatherSearchResponse, string> _restClient;
        public SearchService(IConfiguration configuration, HttpClient http)
        {
            _http = http;
            _baseUrl = configuration["API_WeatherEndpoint"];
            _restClient = new RestClient<WeatherSearchResponse, string>(_baseUrl, "api/location/");
        }
        public async Task<WeatherSearchResponse> SearchWeatherForLocationNr(string location)
        {
            var response = await _restClient.GetAsync(location);
            return response;
        }
    }
}
