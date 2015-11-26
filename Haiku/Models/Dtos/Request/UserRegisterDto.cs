using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haiku.Models.Dtos.Request
{
    public class UserRegisterDto
    {
        [Required]
        [MinLength(4)]
        public string Nickname { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(30)]
        public string PublishToken { get; set; }
    }
}