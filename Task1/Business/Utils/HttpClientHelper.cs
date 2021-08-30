using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Business.Utils
{
    public class RestClient<TResource, TIdentifier> 
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
     
    }
}
