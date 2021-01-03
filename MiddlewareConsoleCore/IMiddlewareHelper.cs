using MiddlewareLibraryCore;
using System.Collections.Generic;

namespace MiddlewareConsoleCore
{
    public interface IMiddlewareHelper<T>
    {
        TResult SubmitDocument<TResult>(string url, T document);
        List<TResult> SubmitDocuments<TResult>(string url, T documents);

        T GetDocumentDetails(string url, string uuid);
        TResult CancelDocument<TResult>(string url, string uuid, T reason);
        TResult RejectDocument<TResult>(string url, string uuid, T reason);
    }

    public class XmlMiddlewareHelper<T> : IMiddlewareHelper<T> where T : class
    {
        private readonly IHttpClientHelper<T> _helper;

        public XmlMiddlewareHelper(IHttpClientHelper<T> helper)
        {
            _helper = helper;
        }

        public TResult SubmitDocument<TResult>(string url, T document)
        {
            try
            {
                return _helper.PostAsync<TResult>(url, document).Result;
            }
            catch
            {
                throw;
            }
        }

        public List<TResult> SubmitDocuments<TResult>(string url, T documents)
        {
            try
            {
                return _helper.PostAsync<List<TResult>>(url, documents).Result;
            }
            catch
            {
                throw;
            }
        }

        public T GetDocumentDetails(string url, string uuid)
        {
            try
            {
                return _helper.GetAsync(url).Result;
            }
            catch
            {
                throw;
            }
        }

        public TResult CancelDocument<TResult>(string url, string uuid, T reason)
        {
            try
            {
                return _helper.PutAsync<TResult>(url, reason).Result;
            }
            catch
            {
                throw;
            }
        }

        public TResult RejectDocument<TResult>(string url, string uuid, T reason)
        {
            try
            {
                return _helper.PutAsync<TResult>(url, reason).Result;
            }
            catch
            {
                throw;
            }
        }
    }

    public class JsonMiddlewareHelper<T> : IMiddlewareHelper<T> where T : class
    {
        private readonly IHttpClientHelper<T> _helper;

        public JsonMiddlewareHelper(IHttpClientHelper<T> helper)
        {
            _helper = helper;
        }

        public TResult SubmitDocument<TResult>(string url, T document)
        {
            try
            {
                return _helper.PostAsync<TResult>(url, document).Result;
            }
            catch
            {
                throw;
            }
        }

        public List<TResult> SubmitDocuments<TResult>(string url, T documents)
        {
            try
            {
                return _helper.PostAsync<List<TResult>>(url, documents).Result;
            }
            catch
            {
                throw;
            }
        }


        public T GetDocumentDetails(string url, string uuid)
        {
            try
            {
                return _helper.GetAsync(url).Result;
            }
            catch
            {
                throw;
            }
        }

        public TResult CancelDocument<TResult>(string url, string uuid, T reason)
        {
            try
            {
                return _helper.PutAsync<TResult>(url, reason).Result;
            }
            catch
            {
                throw;
            }
        }

        public TResult RejectDocument<TResult>(string url, string uuid, T reason)
        {
            try
            {
                return _helper.PutAsync<TResult>(url, reason).Result;
            }
            catch
            {
                throw;
            }
        }
    }
}