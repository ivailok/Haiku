using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Haiku.Web.Filters;
using Haiku.DTO.Request;
using Haiku.DTO.Response;

namespace Haiku.Web.ApiControllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : BaseController
    {
        [HttpGet]
        [Route("")]
        [Administrator]
        public async Task<IHttpActionResult> GetAll(
            [FromUri]ReportsGetQueryParams queryParams)
        {
            return Ok(new ReportGetDto[]
            {
                new ReportGetDto()
                {
                    Reason = "Vulgarno",
                    DateCreated = DateTime.Now
                }
            });
        }
    }
}
