using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Models.Dtos.Response
{
    public class ReportGetDto
    {
        public string Reason { get; set; }

        public DateTime DateCreated { get; set; } 
    }
}