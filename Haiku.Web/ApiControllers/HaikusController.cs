using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Haiku.Web.Filters;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using Haiku.Services;

namespace Haiku.Web.ApiControllers
{
    [RoutePrefix("api/haikus")]
    public class HaikusController : BaseController
    {
        private readonly IHaikusService haikusService;

        public HaikusController(IHaikusService haikusService)
        {
            this.haikusService = haikusService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll([FromUri]HaikusGetQueryParams queryParams)
        {
            var metadata = this.haikusService.GetHaikusPagingMetadata();
            var haikus = await this.haikusService.GetHaikusAsync(queryParams).ConfigureAwait(false);
            var paging = new PagingDto<HaikuGetDto>()
            {
                Metadata = metadata,
                Results = haikus
            };
            return Ok(paging);
        }

        [HttpPost]
        [Route("{id}/ratings")]
        public async Task<IHttpActionResult> Rate(int id, [FromBody]HaikuRateDto dto)
        {
            await this.haikusService.RateAsync(id, dto).ConfigureAwait(false);
            return CreatedWithoutLocationAndContent();
        }

        [HttpPost]
        [Route("{id}/reports")]
        public async Task<IHttpActionResult> SendReport(int id, [FromBody]HaikuReportingDto dto)
        {
            await this.haikusService.SendReport(id, dto).ConfigureAwait(false);
            return CreatedWithoutLocationAndContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [Administrator]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await this.haikusService.DeleteHaikuAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}