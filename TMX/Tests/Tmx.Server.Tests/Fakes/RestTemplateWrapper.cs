namespace Tmx.Server.Tests.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Library.Modules;
    using Nancy.Testing;
    using Spring.Http;
    using Spring.Http.Converters;
    using Spring.Rest.Client;

    // public class RestTemplateWrapper : RestTemplate // , IRestOperations
    public class RestTemplateWrapper : IRestOperations
    {
        Browser _browser;
        public IList<IHttpMessageConverter> MessageConverters { get; set; }
        string _baseUrl;
        BrowserResponse _response;

        public RestTemplateWrapper(string baseUrl)
        {
            _baseUrl = baseUrl;
            _browser = new Browser(with => with.Modules(typeof(TestClientsModule), typeof(TestRunsModule)));
        }

        public T GetForObject<T>(string url, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetForObject<T>(string url, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetForObject<T>(Uri url) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> GetForMessage<T>(string url, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> GetForMessage<T>(string url, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> GetForMessage<T>(Uri url) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpHeaders HeadForHeaders(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public HttpHeaders HeadForHeaders(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public HttpHeaders HeadForHeaders(Uri url)
        {
            throw new NotImplementedException();
        }

        public Uri PostForLocation(string url, object request, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Uri PostForLocation(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Uri PostForLocation(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public T PostForObject<T>(string url, object request, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T PostForObject<T>(string url, object request, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T PostForObject<T>(Uri url, object request) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> PostForMessage<T>(string url, object request, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> PostForMessage<T>(string url, object request, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> PostForMessage<T>(Uri url, object request) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage PostForMessage(string url, object request, params object[] uriVariables)
        {
            // throw new NotImplementedException();

            /*
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.JsonBody(testClient);
                with.Accept("application/json");
            });
            return _response.Body.DeserializeJson<TestClient>();
            */

            _response = _browser.Post(_baseUrl + url, with =>
            {
                with.JsonBody(request);
                with.Accept("application/json");
            });
            var headers = new HttpHeaders();
            headers.Add(Tmx_Core_Resources.NewTestRun_lastTestRunId, _response.Headers[Tmx_Core_Resources.NewTestRun_lastTestRunId]);
Console.WriteLine(_response.Headers[Tmx_Core_Resources.NewTestRun_lastTestRunId]);
            return new HttpResponseMessage(headers, (HttpStatusCode) _response.StatusCode, string.Empty);
        }

        public HttpResponseMessage PostForMessage(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage PostForMessage(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public void Put(string url, object request, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public void Put(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public void Put(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public void Delete(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public void Delete(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public void Delete(Uri url)
        {
            throw new NotImplementedException();
        }

        public IList<HttpMethod> OptionsForAllow(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public IList<HttpMethod> OptionsForAllow(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public IList<HttpMethod> OptionsForAllow(Uri url)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> Exchange<T>(string url, HttpMethod method, HttpEntity requestEntity, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> Exchange<T>(string url, HttpMethod method, HttpEntity requestEntity, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage<T> Exchange<T>(Uri url, HttpMethod method, HttpEntity requestEntity) where T : class
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Exchange(string url, HttpMethod method, HttpEntity requestEntity, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Exchange(string url, HttpMethod method, HttpEntity requestEntity, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Exchange(Uri url, HttpMethod method, HttpEntity requestEntity)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string url, HttpMethod method, IRequestCallback requestCallback, IResponseExtractor<T> responseExtractor,
            params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string url, HttpMethod method, IRequestCallback requestCallback, IResponseExtractor<T> responseExtractor,
            IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(Uri url, HttpMethod method, IRequestCallback requestCallback, IResponseExtractor<T> responseExtractor) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForObjectAsync<T>(string url, Action<RestOperationCompletedEventArgs<T>> getCompleted, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForObjectAsync<T>(string url, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<T>> getCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForObjectAsync<T>(Uri url, Action<RestOperationCompletedEventArgs<T>> getCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForMessageAsync<T>(string url, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> getCompleted, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForMessageAsync<T>(string url, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> getCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler GetForMessageAsync<T>(Uri url, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> getCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler HeadForHeadersAsync(string url, Action<RestOperationCompletedEventArgs<HttpHeaders>> headCompleted, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler HeadForHeadersAsync(string url, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<HttpHeaders>> headCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler HeadForHeadersAsync(Uri url, Action<RestOperationCompletedEventArgs<HttpHeaders>> headCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForLocationAsync(string url, object request, Action<RestOperationCompletedEventArgs<Uri>> postCompleted,
            params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForLocationAsync(string url, object request, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<Uri>> postCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForLocationAsync(Uri url, object request, Action<RestOperationCompletedEventArgs<Uri>> postCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForObjectAsync<T>(string url, object request, Action<RestOperationCompletedEventArgs<T>> postCompleted,
            params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForObjectAsync<T>(string url, object request, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<T>> postCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForObjectAsync<T>(Uri url, object request, Action<RestOperationCompletedEventArgs<T>> postCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync<T>(string url, object request, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> postCompleted,
            params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync<T>(string url, object request, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> postCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync<T>(Uri url, object request, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> postCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync(string url, object request, Action<RestOperationCompletedEventArgs<HttpResponseMessage>> postCompleted, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync(string url, object request, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<HttpResponseMessage>> postCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PostForMessageAsync(Uri url, object request, Action<RestOperationCompletedEventArgs<HttpResponseMessage>> postCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PutAsync(string url, object request, Action<RestOperationCompletedEventArgs<object>> putCompleted, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PutAsync(string url, object request, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<object>> putCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler PutAsync(Uri url, object request, Action<RestOperationCompletedEventArgs<object>> putCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler DeleteAsync(string url, Action<RestOperationCompletedEventArgs<object>> deleteCompleted, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler DeleteAsync(string url, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<object>> deleteCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler DeleteAsync(Uri url, Action<RestOperationCompletedEventArgs<object>> deleteCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler OptionsForAllowAsync(string url, Action<RestOperationCompletedEventArgs<IList<HttpMethod>>> optionsCompleted, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler OptionsForAllowAsync(string url, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<IList<HttpMethod>>> optionsCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler OptionsForAllowAsync(Uri url, Action<RestOperationCompletedEventArgs<IList<HttpMethod>>> optionsCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync<T>(string url, HttpMethod method, HttpEntity requestEntity, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> methodCompleted,
            params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync<T>(string url, HttpMethod method, HttpEntity requestEntity, IDictionary<string, object> uriVariables,
            Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> methodCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync<T>(Uri url, HttpMethod method, HttpEntity requestEntity, Action<RestOperationCompletedEventArgs<HttpResponseMessage<T>>> methodCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync(string url, HttpMethod method, HttpEntity requestEntity, Action<RestOperationCompletedEventArgs<HttpResponseMessage>> methodCompleted,
            params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync(string url, HttpMethod method, HttpEntity requestEntity, IDictionary<string, object> uriVariables,
            Action<RestOperationCompletedEventArgs<HttpResponseMessage>> methodCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExchangeAsync(Uri url, HttpMethod method, HttpEntity requestEntity, Action<RestOperationCompletedEventArgs<HttpResponseMessage>> methodCompleted)
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExecuteAsync<T>(string url, HttpMethod method, IRequestCallback requestCallback,
            IResponseExtractor<T> responseExtractor, Action<RestOperationCompletedEventArgs<T>> methodCompleted, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExecuteAsync<T>(string url, HttpMethod method, IRequestCallback requestCallback,
            IResponseExtractor<T> responseExtractor, IDictionary<string, object> uriVariables, Action<RestOperationCompletedEventArgs<T>> methodCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public RestOperationCanceler ExecuteAsync<T>(Uri url, HttpMethod method, IRequestCallback requestCallback,
            IResponseExtractor<T> responseExtractor, Action<RestOperationCompletedEventArgs<T>> methodCompleted) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetForObjectAsync<T>(string url, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetForObjectAsync<T>(string url, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetForObjectAsync<T>(Uri url) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> GetForMessageAsync<T>(string url, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> GetForMessageAsync<T>(string url, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> GetForMessageAsync<T>(Uri url) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpHeaders> HeadForHeadersAsync(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpHeaders> HeadForHeadersAsync(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpHeaders> HeadForHeadersAsync(Uri url)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostForLocationAsync(string url, object request, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostForLocationAsync(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostForLocationAsync(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostForObjectAsync<T>(string url, object request, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> PostForObjectAsync<T>(string url, object request, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> PostForObjectAsync<T>(Uri url, object request) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> PostForMessageAsync<T>(string url, object request, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> PostForMessageAsync<T>(string url, object request, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> PostForMessageAsync<T>(Uri url, object request) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostForMessageAsync(string url, object request, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostForMessageAsync(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostForMessageAsync(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(string url, object request, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(string url, object request, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(Uri url, object request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Uri url)
        {
            throw new NotImplementedException();
        }

        public Task<IList<HttpMethod>> OptionsForAllowAsync(string url, params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<IList<HttpMethod>> OptionsForAllowAsync(string url, IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<IList<HttpMethod>> OptionsForAllowAsync(Uri url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> ExchangeAsync<T>(string url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken,
            params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> ExchangeAsync<T>(string url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken,
            IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage<T>> ExchangeAsync<T>(Uri url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ExchangeAsync(string url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken,
            params object[] uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ExchangeAsync(string url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken,
            IDictionary<string, object> uriVariables)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ExchangeAsync(Uri url, HttpMethod method, HttpEntity requestEntity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteAsync<T>(string url, HttpMethod method, IRequestCallback requestCallback,
            IResponseExtractor<T> responseExtractor, CancellationToken cancellationToken, params object[] uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteAsync<T>(string url, HttpMethod method, IRequestCallback requestCallback,
            IResponseExtractor<T> responseExtractor, CancellationToken cancellationToken, IDictionary<string, object> uriVariables) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteAsync<T>(Uri url, HttpMethod method, IRequestCallback requestCallback, IResponseExtractor<T> responseExtractor,
            CancellationToken cancellationToken) where T : class
        {
            throw new NotImplementedException();
        }
    }
}