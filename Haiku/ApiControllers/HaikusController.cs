using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Haiku.Filters;
using Haiku.Models.Dtos;
using Haiku.Models.Dtos.Request;
using Haiku.Models.Dtos.Response;

namespace Haiku.ApiControllers
{
    [RoutePrefix("api/haikus")]
    public class HaikusController : BaseController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll([FromUri]HaikusGetQueryParams queryParams)
        {
            return Ok(new HaikuGetDto[] { new HaikuGetDto() { Id = 3, Rating = 3.3, Text = "Haikus are nice."} });
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