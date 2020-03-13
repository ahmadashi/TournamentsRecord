using Newtonsoft.Json;
using TR.Utilities.HttpClientWrapper.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TR.Utilities.HttpClientWrapper
{
    public class HttpClientWrapper: IHttpClientWrapper
    {
        IHttpClientFactory _clientFactory;
        protected HttpClient Client { get; set; }
        private string _key = "";

        public HttpClientWrapper(            
            IHttpClientFactory httpClientFactory//,            
            //HttpClientConfigurationItem httpClientConfigurationItem
            )
        {
             //_clientFactory = httpClientFactory;
            //Ashi: Change the name later to be configable
            //Client = httpClientFactory.CreateClient("API");
            _clientFactory = httpClientFactory;
        }

        public void setClientKey(string key)
        {
           _key = key;
            Client = _clientFactory.CreateClient(_key);
        }

        public HttpClient GetClient() => Client;

        public void AddHeader(string name, string value)
            => Client.DefaultRequestHeaders.Add(name, value);

        public void AddAuthenticationHeader(string type, string value)
            => Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, value);

        public Task<byte[]> GetAsync(string address)
            => RawResponseAsync(Client.GetAsync(address).Result);

        public Task<byte[]> PostAsync(string uri, HttpContent content)
            => RawResponseAsync(Client.PostAsync(uri, content).Result);

        public Task<byte[]> PutAsync(string uri, HttpContent content)
            => RawResponseAsync(Client.PutAsync(uri, content).Result);

        public Task<byte[]> DeleteAsync(string uri)
            => RawResponseAsync(Client.DeleteAsync(uri).Result);

        public Task<T> GetAsync<T>(string address) where T : class
            => DeserializeResponseAsync<T>(Client.GetAsync(address).Result);

        public Task<T> PostAsync<T>(string uri, HttpContent content) where T : class
            => DeserializeResponseAsync<T>(Client.PostAsync(uri, content).Result);

        public Task<T> PutAsync<T>(string uri, HttpContent content) where T : class
            => DeserializeResponseAsync<T>(Client.PutAsync(uri, content).Result);

        public Task<T> DeleteAsync<T>(string uri) where T : class
            => DeserializeResponseAsync<T>(Client.DeleteAsync(uri).Result);

        private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response) where T : class
        {
            response.EnsureSuccessStatusCode();


            var content = await response.Content.ReadAsStringAsync();

            // Convert the returned type from the endpoint to the desired object type
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;

            //var data = await response
            //    .Content
            //    .ReadAsByteArrayAsync();

            //return _serializer
            //    .DeserializeTo<T>(data);
        }

        private async Task<byte[]> RawResponseAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var data = await response
                .Content
                .ReadAsByteArrayAsync();

            return data;
        }
    }
}
