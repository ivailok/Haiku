using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.Data;
using Haiku.Data.Entities;
using System.Threading;

namespace Haiku.Services
{
    public class UsersService : IUsersService
    {
        private readonly UnitOfWork unitOfWork;

        public UsersService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public Task RegisterAuthorAsync(AuthorRegisterDto dto)
        {
            User user = Mapper.MapAuthorRegisterDtoToUser(dto);
            this.unitOfWork.UsersRepository.Add(user);
            return this.unitOfWork.SaveAsync();
        }
    }
}
