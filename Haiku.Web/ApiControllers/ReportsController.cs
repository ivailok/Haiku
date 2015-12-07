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
using Haiku.Services;

namespace Haiku.Web.ApiControllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : BaseController
    {
        private IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        [HttpGet]
        [Route("")]
        [Administrator]
        public async Task<IHttpActionResult> GetAll(
            [FromUri]ReportsGetQueryParams queryParams)
        {
            var reports = await this.reportsService.GetReportsAsync(queryParams).ConfigureAwait(false);
            return Ok(reports);
        }
    }
}
