using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Routing;
using Haiku.Web.Filters;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using Haiku.Services;
using System.Threading;

namespace Haiku.Web.ApiControllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly IHaikusService haikusService;

        public UsersController(IUsersService usersService, IHaikusService haikusService)
        {
            this.usersService = usersService;
            this.haikusService = haikusService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> RegisterAuthor([FromBody]AuthorRegisteringDto dto)
        {
            await this.usersService.RegisterAuthorAsync(dto).ConfigureAwait(false);
            return CreatedWithoutLocationAndContent();
        }

        [HttpPost]
        [Route("{nickname}/haikus")]
        [Author]
        public async Task<IHttpActionResult> PublishHaiku(
            string nickname, [FromBody]HaikuPublishingDto dto)
        {
            var published = await this.usersService.PublishHaikuAsync(nickname, dto).ConfigureAwait(false);
            return CreatedWithoutLocation(published);
        }

        [HttpDelete]
        [Route("{nickname}/haikus/{haikuId}")]
        [Author]
        public async Task<IHttpActionResult> DeleteHaiku(
            string nickname, int haikuId)
        {
            await this.haikusService.DeleteHaikuAsync(haikuId).ConfigureAwait(false);
            return NoContent();
        }

        [HttpPut]
        [Route("{nickname}/haikus/{haikuId}")]
        [Author]
        public async Task<IHttpActionResult> ModifyHaiku(
            string nickname, int haikuId, [FromBody]HaikuModifyDto dto)
        {
            await this.haikusService.ModifyHaikuAsync(haikuId, dto);
            return NoContent();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll([FromUri]UsersGetQueryParams queryParams)
        {
            var metadata = this.usersService.GetUsersPagingMetadata();
            var users = await this.usersService.GetUsersAsync(queryParams).ConfigureAwait(false);
            var paging = new PagingDto<UserGetDto>()
            {
                Metadata = metadata,
                Results = users
            };
            return Ok(paging);
        }

        [HttpGet]
        [Route("{nickname}")]
        public async Task<IHttpActionResult> Get(string nickname)
        {
            var user = await this.usersService.GetUserAsync(nickname).ConfigureAwait(false);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{nickname}/haikus")]
        [Author]
        public async Task<IHttpActionResult> DeleteHaikus(string nickname)
        {
            await this.usersService.DeleteHaikusAsync(nickname).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete]
        [Route("{nickname}")]
        [Administrator]
        public async Task<IHttpActionResult> Delete(string nickname)
        {
            await this.usersService.DeleteProfileAsync(nickname).ConfigureAwait(false);
            return NoContent();
        }

        [HttpPut]
        [Route("{nickname}")]
        [Administrator]
        public async Task<IHttpActionResult> ChangeUserRole(string nickname, [FromUri]ChangeableUserRole role)
        {
            await this.usersService.ChangeUserRoleAsync(nickname, role).ConfigureAwait(false);
            return NoContent();
        }
    }
}