using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using Haiku.Data;
using Haiku.Data.Entities;
using System.Linq.Expressions;

namespace Haiku.Services
{
    public class HaikusService : IHaikusService
    {
        private readonly IUnitOfWork unitOfWork;

        public HaikusService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task DeleteHaikuAsync(int haikuId)
        {
            await DeleteHaikuNFAsync(haikuId).ConfigureAwait(false);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
        }

        public async Task DeleteHaikuNFAsync(int haikuId)
        {
            this.unitOfWork.ReportsRepository.DeleteMany(r => r.HaikuId == haikuId);
            this.unitOfWork.RatingsRepository.DeleteMany(r => r.HaikuId == haikuId);
            await this.unitOfWork.HaikusRepository.DeleteAsync(haikuId).ConfigureAwait(false);
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
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<HaikuGetDto>> GetHaikusAsync(HaikusGetQueryParams queryParams)
        {
            IList<HaikuEntity> data;
            if (queryParams.SortBy == HaikusSortBy.Date)
            {
                data = await this.unitOfWork.HaikusRepository.GetAllAsync(
                    h => h.DatePublished, queryParams.Order == OrderType.Ascending, 
                    queryParams.Skip, queryParams.Take).ConfigureAwait(false);
            }
            else
            {
                data = await this.unitOfWork.HaikusRepository.GetAllAsync(
                    h => h.Rating, queryParams.Order == OrderType.Ascending,
                    queryParams.Skip, queryParams.Take).ConfigureAwait(false);
            }

            return data.Select(h => Mapper.MapHaikuEntityToHaikuGetDto(h));
        }

        public async Task RateAsync(int id, HaikuRateDto dto)
        {
            var haiku = await this.unitOfWork.HaikusRepository.GetByIdAsync(id).ConfigureAwait(false);
            var rating = Mapper.MapHaikuRateDtoToHaikuRating(dto);
            haiku.Ratings.Add(rating);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
        }

        public async Task SendReport(int id, HaikuReportingDto dto)
        {
            var haiku = await this.unitOfWork.HaikusRepository.GetByIdAsync(id).ConfigureAwait(false);
            var report = Mapper.MapHaikuReportingDtoToReport(dto);
            haiku.Reports.Add(report);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
}
