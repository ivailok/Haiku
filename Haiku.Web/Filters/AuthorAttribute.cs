using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Haiku.Web.Filters
{
    public class AuthorAttribute : ActionFilterAttribute
    {
        private const string PublishTokenHeader = "PublishCode";

        public override Task OnActionExecutingAsync(
            HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            bool author = false;

            string token;
            if (HeaderExtractor.ExtractHeader(actionContext.Request.Headers, PublishTokenHeader, out token))
            {
                if (token == "123") // magic here
                {
                    author = true;
                }
            }

            if (!author)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}