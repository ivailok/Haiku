using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.DTO.Request
{
    public class AuthorRegisterDto
    {
        public string Nickname { get; set; }
        
        public string PublishToken { get; set; }
    }
}