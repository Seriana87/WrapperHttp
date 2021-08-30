using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Task1.Business.Contract.Weather;
using Task1.Business.Interface;
using Task1.Contract.Weather;

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
            #region HttpClient
            // With HttpClient Helper
            //string url = $@"{_baseUrl}/api/location/{location}";

            //var response = await HttpClientHelper.SendRequestAsync("", _http, HttpMethod.Get, url, "", "");
            //var content = await response.Content.ReadAsStringAsync();
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new HttpRequestException($"Could not retrieve weather from {url}. Error: {content}");
            //}

            //return JsonConvert.DeserializeObject<WeatherSearchResponse>(content);
            #endregion

            // With RestClient
            var response = await _restClient.GetAsync(location);
            return response;

        }
    }
}
