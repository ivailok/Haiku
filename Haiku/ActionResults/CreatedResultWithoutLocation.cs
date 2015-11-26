using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Haiku.ActionResults
{
    public class CreatedResultWithoutLocation<T> : IHttpActionResult
    {
        private readonly HttpRequestMessage request;
        private readonly T data;

        public CreatedResultWithoutLocation(HttpRequestMessage request, T data)
        {
            this.request = request;
            this.data = data;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = this.request.CreateResponse(HttpStatusCode.Created, data);
            return Task.FromResult(response);
        }
    }
}