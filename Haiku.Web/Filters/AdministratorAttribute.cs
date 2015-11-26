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
    public class AdministratorAttribute : ActionFilterAttribute
    {
        private const string AdminTokenHeader = "ManageToken";

        public override Task OnActionExecutingAsync(
            HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            bool admin = false;

            string token;
            if (HeaderExtractor.ExtractHeader(actionContext.Request.Headers, AdminTokenHeader, out token))
            {
                if (token == "321") // magic here
                {
                    admin = true;
                }
            }

            if (!admin)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}