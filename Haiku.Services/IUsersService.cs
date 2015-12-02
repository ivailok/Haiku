using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;

namespace Haiku.Services
{
    public interface IUsersService
    {
        Task RegisterAuthorAsync(AuthorRegisterDto dto);
    }
}
