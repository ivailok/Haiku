using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Haiku.Web.ActionResults;

namespace Haiku.Web.ApiControllers
{
    public class BaseController : ApiController
    {
        protected CreatedResultWithoutLocation<T> CreatedWithoutLocation<T>(T data)
        {
            return new CreatedResultWithoutLocation<T>(this.Request, data);
        }

        protected NoContentResult NoContent()
        {
            return new NoContentResult(this.Request);
        }

        protected CreatedResultWithoutLocationAndContent CreatedWithoutLocationAndContent()
        {
            return new CreatedResultWithoutLocationAndContent(this.Request);
        }
    }
}