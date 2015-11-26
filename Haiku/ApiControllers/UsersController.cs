using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Routing;
using Haiku.Filters;
using Haiku.Models.Dtos.Request;
using Haiku.Models.Dtos.Response;

namespace Haiku.ApiControllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseController
    {
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateUser([FromBody]UserRegisterDto dto)
        {
            return CreatedWithoutLocationAndContent();
        }

        [HttpPost]
        [Route("{username}/haikus")]
        [Author]
        public async Task<IHttpActionResult> PublishHaiku(
            string username, [FromBody]HaikuPublishDto dto)
        {
            return CreatedWithoutLocation(new CreatedHaikuDto()
            {
                Id = 10,
                DatePublished = DateTime.Now
            });
        }

        [HttpDelete]
        [Route("{username}/haikus/{haikuId}")]
        [Author]
        public async Task<IHttpActionResult> DeleteHaiku(
            string username, int haikuId)
        {
            return NoContent();
        }

        [HttpPut]
        [Route("{username}/haikus/{haikuId}")]
        [Author]
        public async Task<IHttpActionResult> ModifyHaiku(
            string username, int haikuId, [FromBody]HaikuModifyDto dto)
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