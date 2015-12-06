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
            var data = await this.haikusService.GetHaikusAsync(queryParams).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpPost]
        [Route("{id}/ratings")]
        public async Task<IHttpActionResult> Rate(int id, [FromBody]HaikuRateDto dto)
        {
            return CreatedWithoutLocationAndContent();
        }

        [HttpPost]
        [Route("{id}/reports")]
        public async Task<IHttpActionResult> SendReport(int id)
        {
            return CreatedWithoutLocationAndContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [Administrator]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}