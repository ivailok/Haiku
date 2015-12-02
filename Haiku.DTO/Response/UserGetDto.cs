using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.DTO.Response
{
    public class UserGetDto
    {
        public string Username { get; set; }

        public double Rating { get; set; }

        public IEnumerable<HaikuGetDto> Haikus { get; set; } 
    }
}