﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Models.Dtos.Request
{
    public enum HaikusSortBy
    {
        Date = 1,
        Rating = 2,
    }

    public class HaikusGetQueryParams : PagingQueryParams
    {
        public HaikusSortBy SortBy { get; set; }

        public OrderType Order { get; set; }
    }
}