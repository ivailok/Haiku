using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.Data;
using Haiku.Data.Entities;
using System.Threading;
using Haiku.DTO.Response;

namespace Haiku.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private User FindUserByNickname(string nickname)
        {
            var user = this.unitOfWork.UsersRepository.Query()
                .Where(u => u.Nickname == nickname).SingleOrDefault();

            if (user == null)
            {
                throw new Exception("Author not found.");
            }

            return user;
        }

        public bool ConfirmAuthorIdentity(string nickname, string publishCode)
        {
            var user = FindUserByNickname(nickname);
            if (user.AccessToken == publishCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task RegisterAuthorAsync(AuthorRegisteringDto dto)
        {
            User user = Mapper.MapAuthorRegisterDtoToUser(dto);
            this.unitOfWork.UsersRepository.Add(user);
            return this.unitOfWork.SaveAsync();
        }

        public async Task<HaikuPublishedDto> PublishHaikuAsync(string nickname, HaikuPublishingDto dto)
        {
            var user = FindUserByNickname(nickname);

            var haiku = Mapper.MapHaikuPublishingDtoToHaikuEntity(dto);
            haiku.DatePublished = DateTime.Now;
            haiku.User = user;

            var addedHaiku = this.unitOfWork.HaikusRepository.Add(haiku);
            await this.unitOfWork.SaveAsync().ConfigureAwait(false);

            var published = Mapper.MapHaikuEntityToHaikuPublishedDto(addedHaiku);
            return published;
        }

        public async Task DeleteHaikuAsync(string nickname, int haikuId)
        {
            var user = FindUserByNickname(nickname);
            await this.unitOfWork.HaikusRepository.DeleteAsync(haikuId).ConfigureAwait(false);
            await this.unitOfWork.SaveAsync();
        }
    }
}
