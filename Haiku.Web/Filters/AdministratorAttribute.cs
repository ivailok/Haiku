using Haiku.Services;
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
    public class AdministratorAttribute : AuthorizationFilterAttribute
    {
        private const string AdminTokenHeader = "ManageToken";

        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            // per request lifetime
            var requestScope = actionContext.Request.GetDependencyScope();
            var usersService = requestScope.GetService(typeof(IUsersService)) as IUsersService;

            bool admin = false;

            string token;
            if (HeaderExtractor.ExtractHeader(actionContext.Request.Headers, AdminTokenHeader, out token))
            {
                if (await usersService.ConfirmAdministratorIdentityAsync(token).ConfigureAwait(false))
                {
                    admin = true;
                }
            }

            if (!admin)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Wrong credentials.");
            }
        }
    }
}