using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WarAndPeace.UI.Shared
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<HttpResponseMessage> GetResponse(HttpMethod method, string uri)
        {
            var request = BuildRequest(method, _httpClient.BaseAddress + uri);
            return _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        }

        public void Dispose() => _httpClient?.Dispose();

        private static HttpRequestMessage BuildRequest(HttpMethod method, string uri)
        {
            HttpRequestMessage request = new(method, uri);
            return request;
        }
    }

}
