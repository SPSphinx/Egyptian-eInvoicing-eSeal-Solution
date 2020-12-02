using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiddlewareLibraryCore
{
    public interface IHttpClientHelper<T> where T : class
    {
        Task<T> GetAsync(string url);

        Task<TResult> PostAsync<TResult>(string url, T postObject);
    }

    public class HttpClientHelper<T> : IDisposable, IHttpClientHelper<T> where T : class
    {
        private readonly HttpClient _client;

        public HttpClientHelper()
        {
            _client = new HttpClient();
        }

        #region Implementation of IDisposable Interface

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Implementation of IHttpClientHelper Interface

        public async Task<T> GetAsync(string url)
        {
            T result;

            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<T>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();

                throw new HttpRequestException($"{response.StatusCode}: {content}");
            }

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string url, T postObject)
        {
            TResult result;

            var jsonToPost = JsonSerializer.Serialize(postObject, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });
            var postContent = new StringContent(jsonToPost, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, postContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<TResult>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();

                throw new HttpRequestException($"{response.StatusCode}: {content}");
            }

            return result;
        }

        #endregion
    }
}