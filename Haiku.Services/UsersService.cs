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

        private async Task<User> FindUserByNicknameAsync(string nickname)
        {
            var user = await this.unitOfWork.UsersRepository
                .GetUniqueAsync(u => u.Nickname == nickname).ConfigureAwait(false);

            if (user == null)
            {
                throw new Exception("Author not found.");
            }

            return user;
        }

        public async Task<bool> ConfirmAuthorIdentity(string nickname, string publishCode)
        {
            var user = await FindUserByNicknameAsync(nickname).ConfigureAwait(false);
            if (user.AccessToken == publishCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task RegisterAuthorAsync(AuthorRegisteringDto dto)
        {
            User user = Mapper.MapAuthorRegisterDtoToUser(dto);
            this.unitOfWork.UsersRepository.Add(user);
            await this.unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task<HaikuPublishedDto> PublishHaikuAsync(string nickname, HaikuPublishingDto dto)
        {
            var user = await FindUserByNicknameAsync(nickname).ConfigureAwait(false);

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
            await this.unitOfWork.HaikusRepository.DeleteAsync(haikuId).ConfigureAwait(false);
            await this.unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserGetDto>> GetUsersAsync(UsersGetQueryParams queryParams)
        {
            IList<User> data;
            if (queryParams.SortBy == UsersSortBy.Nickname)
            {
                data = await this.unitOfWork.UsersRepository.GetAllAsync(
                    u => u.Nickname, queryParams.Order == OrderType.Ascending,
                    queryParams.Skip, queryParams.Take).ConfigureAwait(false);
            }
            else
            {
                data = await this.unitOfWork.UsersRepository.GetAllAsync(
                    u => u.Rating, queryParams.Order == OrderType.Ascending,
                    queryParams.Skip, queryParams.Take).ConfigureAwait(false);
            }

            return data.Select(u => Mapper.MapUserToUserGetDto(u)); 
        }

        public async Task<UserGetDto> GetUserAsync(string nickname)
        {
            var user = await FindUserByNicknameAsync(nickname).ConfigureAwait(false);
            return Mapper.MapUserToUserGetDto(user); 
        }
    }
}
