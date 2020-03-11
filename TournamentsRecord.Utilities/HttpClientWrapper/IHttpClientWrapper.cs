using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TournamentsRecord.Utilities.HttpClientWrapper
{
    public interface IHttpClientWrapper
    {
        void setClientKey(string key);
        void AddHeader(string name, string value);

        void AddAuthenticationHeader(string value, string type);

        Task<byte[]> GetAsync(string address);

        Task<byte[]> PostAsync(string uri, HttpContent content);

        Task<byte[]> PutAsync(string uri, HttpContent content);

        Task<byte[]> DeleteAsync(string uri);

        Task<T> GetAsync<T>(string address) where T : class;

        Task<T> PostAsync<T>(string uri, HttpContent content) where T : class;

        Task<T> PutAsync<T>(string uri, HttpContent content) where T : class;

        Task<T> DeleteAsync<T>(string uri) where T : class;
    }
}
