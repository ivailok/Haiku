using Haiku.Data.Entities;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Services
{
    public static class Mapper
    {
        public static User MapAuthorRegisterDtoToUser(AuthorRegisteringDto dto)
        {
            return new User()
            {
                Nickname = dto.Nickname,
                AccessToken = dto.PublishCode,
                Role = UserRole.Author
            };
        }

        public static HaikuEntity MapHaikuPublishingDtoToHaikuEntity(HaikuPublishingDto dto)
        {
            return new HaikuEntity()
            {
                Text = dto.Text,
            };
        }

        public static HaikuPublishedDto MapHaikuEntityToHaikuPublishedDto(HaikuEntity haiku)
        {
            return new HaikuPublishedDto()
            {
                Id = haiku.Id,
                DatePublished = haiku.DatePublished
            };
        }

        public static HaikuGetDto MapHaikuEntityToHaikuGetDto(HaikuEntity haiku)
        {
            return new HaikuGetDto()
            {
                Id = haiku.Id,
                Text = haiku.Text,
                Rating = haiku.Rating
            };
        }
    }
}
