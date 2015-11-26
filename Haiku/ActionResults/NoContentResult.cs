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
    public class NoContentResult : IHttpActionResult
    {
        private readonly HttpRequestMessage request;

        public NoContentResult(HttpRequestMessage request)
        {
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = this.request.CreateResponse(HttpStatusCode.NoContent);
            return Task.FromResult(response);
        }
    }
}