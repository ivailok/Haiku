using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Web.Models.Dtos.Request
{
    public class PagingQueryParams
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }
}