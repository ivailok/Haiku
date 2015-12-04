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

        private readonly IUsersService usersService;
        
        public AuthorAttribute()
        {
            this.usersService = new UsersService();
        }

        public override Task OnActionExecutingAsync(
            HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            bool author = false;

            string token;
            if (HeaderExtractor.ExtractHeader(actionContext.Request.Headers, PublishTokenHeader, out token))
            {
                if (actionContext.ActionArguments.ContainsKey("nickname") &&
                    this.usersService.ConfirmAuthorIdentity(actionContext.ActionArguments["nickname"].ToString(), token))
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