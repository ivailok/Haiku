using Haiku.Data.Entities;
using Haiku.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Services
{
    public static class Mapper
    {
        public static User MapAuthorRegisterDtoToUser(AuthorRegisterDto dto)
        {
            return new User()
            {
                Nickname = dto.Nickname,
                AccessToken = dto.PublishToken,
                Role = UserRole.Author
            };
        }
    }
}
