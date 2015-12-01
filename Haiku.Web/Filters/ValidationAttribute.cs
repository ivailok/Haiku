using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Haiku.Web.Filters
{
    public class ValidationAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var sb = new StringBuilder();
                foreach (var modelState in actionContext.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        sb.Append(error.ErrorMessage + " ");
                    }
                }
                sb.Remove(sb.Length - 1, 1); // remove last space

                var response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, sb.ToString());
                throw new HttpResponseException(response);
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}