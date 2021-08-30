using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Task1.Business.Contract.Weather
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> SendRequestAsync(object payload, HttpClient httpClient, HttpMethod method, string requestUri, string token, string apimSubscriptionKey)
        {
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(method, requestUri: requestUri);

            return await httpClient.SendAsync(request);
        }
    }

    public class RestClient<TResource, TIdentifier> : IDisposable where TResource : class
    {


        private HttpClient httpClient;
        protected readonly string _baseAddress;
        private readonly string _addressSuffix;
        private bool disposed = false;

        public RestClient(string baseAddress, string addressSuffix)
        {
            _baseAddress = baseAddress;
            _addressSuffix = addressSuffix;
            httpClient = CreateHttpClient(_baseAddress);
        }
        protected virtual HttpClient CreateHttpClient(string serviceBaseAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceBaseAddress);
            return httpClient;
        }
        public async Task<TResource> GetAsync(TIdentifier identifier)
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix + identifier.ToString());
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<TResource>();
        }
        public async Task<IEnumerable<TResource>> GetAll()
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<IEnumerable<TResource>>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
                disposed = true;
            }
        }
    }
}
