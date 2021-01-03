using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiddlewareLibraryCore
{
    public interface IHttpClientHelper<T> where T : class
    {
        Task<T> GetAsync(string url);

        Task<TResult> PostAsync<TResult>(string url, T postObject);

        Task<TResult> PutAsync<TResult>(string url, T puttObject);
    }

    public class JsonHttpClientHelper<T> : IDisposable, IHttpClientHelper<T> where T : class
    {
        private readonly HttpClient _client;

        public JsonHttpClientHelper()
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

                throw new HttpRequestException($"{content}");
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

                throw new HttpRequestException($"{content}");
            }

            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string url, T puttObject)
        {
            TResult result;

            var jsonToPut = JsonSerializer.Serialize(puttObject, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });
            var puttContent = new StringContent(jsonToPut, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, puttContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<TResult>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();

                throw new HttpRequestException($"{content}");
            }

            return result;
        }

        #endregion
    }


    public class XmlHttpClientHelper<T> : IDisposable, IHttpClientHelper<T> where T : class
    {
        private readonly HttpClient _client;

        public XmlHttpClientHelper()
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

                throw new HttpRequestException($"{content}");
            }

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string url, T postObject)
        {
            TResult result;

            var xmlToPost = string.Empty;

            await using (var stringWriter = new Utf8StringWriter())
            {
                var serializer = new XmlSerializer(postObject.GetType());
                serializer.Serialize(stringWriter, postObject);
                xmlToPost = stringWriter.ToString();
            }

            var postContent = new StringContent(xmlToPost, Encoding.UTF8, "application/xml");

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

                throw new HttpRequestException($"{content}");
            }

            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string url, T putObject)
        {
            TResult result;

            var xmlToPut = string.Empty;

            using (var stringWriter = new Utf8StringWriter())
            {
                var serializer = new XmlSerializer(putObject.GetType());
                serializer.Serialize(stringWriter, putObject);
                xmlToPut = stringWriter.ToString();
            }

            var puttContent = new StringContent(xmlToPut, Encoding.UTF8, "application/xml");
            var response = await _client.PostAsync(url, puttContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<TResult>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();

                throw new HttpRequestException($"{content}");
            }

            return result;
        }

        #endregion
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}