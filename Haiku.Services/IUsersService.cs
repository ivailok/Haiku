using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.DTO.Response;

namespace Haiku.Services
{
    public interface IUsersService
    {
        Task RegisterAuthorAsync(AuthorRegisteringDto dto);
        
        Task<HaikuPublishedDto> PublishHaikuAsync(string nickname, HaikuPublishingDto dto);

        Task DeleteHaikuAsync(string nickname, int haikuId);
    }
}
