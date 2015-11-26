using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Web.Models.Dtos.Response
{
    public class CreatedHaikuDto
    {
        public int Id { get; set; }

        public DateTime DatePublished { get; set; }
    }
}