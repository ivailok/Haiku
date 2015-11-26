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
    public class CreatedResultWithoutLocationAndContent : IHttpActionResult
    {
        private readonly HttpRequestMessage request;

        public CreatedResultWithoutLocationAndContent(HttpRequestMessage request)
        {
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = this.request.CreateResponse(HttpStatusCode.Created);
            return Task.FromResult(response);
        }
    }
}