using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Models.Dtos.Request
{
    public enum ReportSortBy
    {
        Date
    }

    public class ReportsGetQueryParams : PagingQueryParams
    {
        public ReportSortBy SortBy { get; set; }
    }
}