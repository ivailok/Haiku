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

        public UsersController()
        {
            this.usersService = new UsersService();
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
            await this.usersService.DeleteHaikuAsync(nickname, haikuId).ConfigureAwait(false);
            return NoContent();
        }

        [HttpPut]
        [Route("{nickname}/haikus/{haikuId}")]
        [Author]
        public async Task<IHttpActionResult> ModifyHaiku(
            string nickname, int haikuId, [FromBody]HaikuModifyDto dto)
        {
            return NoContent();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll([FromUri]UsersGetQueryParams queryParams)
        {
            return Ok(new UserGetDto[]
            {
                new UserGetDto()
                {
                    Username = "Ivaylo",
                    Rating = 4.25,
                    Haikus = new HaikuGetDto[]
                    {
                        new HaikuGetDto()
                        {
                            Id = 1,
                            Rating = 3.5,
                            Text = "Haiku here"
                        },
                        new HaikuGetDto()
                        {
                            Id = 2,
                            Rating = 5,
                            Text = "One more time"
                        }
                    }
                },
                new UserGetDto()
                {
                    Username = "Joe",
                    Rating = 5,
                    Haikus = new HaikuGetDto[]
                    {
                        new HaikuGetDto()
                        {
                            Id = 3,
                            Rating = 5,
                            Text = "My haiku is way better than yours."
                        }
                    }
                }
            });
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<IHttpActionResult> Get(string username)
        {
            return Ok(new UserGetDto()
            {
                Username = "Ivaylo",
                Rating = 4.25,
                Haikus = new HaikuGetDto[]
                {
                    new HaikuGetDto()
                    {
                        Id = 1,
                        Rating = 3.5,
                        Text = "Haiku here"
                    },
                    new HaikuGetDto()
                    {
                        Id = 2,
                        Rating = 5,
                        Text = "One more time"
                    }
                }
            });
        }

        [HttpDelete]
        [Route("{username}/haikus")]
        [Author]
        public async Task<IHttpActionResult> DeleteHaikus(string username)
        {
            return NoContent();
        }

        [HttpDelete]
        [Route("{username}")]
        [Administrator]
        public async Task<IHttpActionResult> Delete(string username)
        {
            return NoContent();
        }
    }
}