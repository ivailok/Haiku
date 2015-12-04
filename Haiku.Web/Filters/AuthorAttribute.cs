using Haiku.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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
            // per request lifetime
            var requestScope = actionContext.Request.GetDependencyScope();
            var usersService = requestScope.GetService(typeof(IUsersService)) as IUsersService;

            bool author = false;

            string token;
            if (HeaderExtractor.ExtractHeader(actionContext.Request.Headers, PublishTokenHeader, out token))
            {
                if (actionContext.ActionArguments.ContainsKey("nickname") &&
                    usersService.ConfirmAuthorIdentity(actionContext.ActionArguments["nickname"].ToString(), token))
                {
                    author = true;
                }
            }

            if (!author)
            {
                var response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(response);
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}