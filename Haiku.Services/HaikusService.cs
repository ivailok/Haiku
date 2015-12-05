using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using Haiku.Data;

namespace Haiku.Services
{
    public class HaikusService : IHaikusService
    {
        private readonly IUnitOfWork unitOfWork;

        public HaikusService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task ModifyHaikuAsync(int haikuId, HaikuModifyDto dto)
        {
            var haiku = await this.unitOfWork.HaikusRepository.GetByIdAsync(haikuId).ConfigureAwait(false);
            if (haiku == null)
            {
                throw new KeyNotFoundException("Haiku not found.");
            }
            haiku.Text = dto.Text;
            this.unitOfWork.HaikusRepository.Update(haiku);
            await this.unitOfWork.SaveAsync().ConfigureAwait(false);
        }
    }
}
