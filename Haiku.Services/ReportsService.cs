using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.Data.Entities;
using Haiku.Data;
using Haiku.DTO.Response;

namespace Haiku.Services
{
    public class ReportsService : IReportsService
    {
        private IUnitOfWork unitOfWork;

        public ReportsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReportGetDto>> GetReportsAsync(ReportsGetQueryParams queryParams)
        {
            IList<Report> reports = await this.unitOfWork.ReportsRepository.GetAllAsync(
                r => r.DateSent, true, queryParams.Skip, queryParams.Take).ConfigureAwait(false);
            return reports.Select(r => Mapper.MapReportToReportGetDto(r));
        }
    }
}
