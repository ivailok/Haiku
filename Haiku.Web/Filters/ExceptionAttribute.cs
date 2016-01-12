using Haiku.DTO.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Haiku.Web.Filters
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotFoundException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            }
            else if (actionExecutedContext.Exception is DuplicateNicknameException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    HttpStatusCode.Conflict, actionExecutedContext.Exception.Message);
            }
            else
            {
                // log here
            }
        }
    }
}