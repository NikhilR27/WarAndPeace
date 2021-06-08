using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WarAndPeace.UI.Shared
{
    public interface IHttpClientWrapper : IDisposable
    {
        Task<HttpResponseMessage> GetResponse(HttpMethod method, string uri);
    }

}
