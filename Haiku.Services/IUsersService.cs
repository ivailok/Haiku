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
        Task<bool> ConfirmAuthorIdentity(string nickname, string publishCode);

        Task RegisterAuthorAsync(AuthorRegisteringDto dto);
        
        Task<HaikuPublishedDto> PublishHaikuAsync(string nickname, HaikuPublishingDto dto);

        Task DeleteHaikuAsync(string nickname, int haikuId);

        Task<IEnumerable<UserGetDto>> GetUsersAsync(UsersGetQueryParams queryParams);

        Task<UserGetDto> GetUserAsync(string nickname);
    }
}
