﻿using System;
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

            if (queryParams.Skip != 0 && queryParams.Skip >= metadata.TotalCount)
            {
                return BadRequest("Requesting data that do not exist. Check your skip parameter.");
            }

            var paging = new PagingDto<HaikuGetDto>()
            {
                Metadata = metadata,
                Results = haikus
            };
            return Ok(paging);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var haiku = await this.haikusService.GetHaikuAsync(id).ConfigureAwait(false);
            return Ok(haiku);
        }

        [HttpPost]
        [Route("{id}/ratings")]
        public async Task<IHttpActionResult> Rate(int id, [FromBody]HaikuRatingDto dto)
        {
            var data = await this.haikusService.RateAsync(id, dto).ConfigureAwait(false);
            return CreatedWithoutLocation(data);
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