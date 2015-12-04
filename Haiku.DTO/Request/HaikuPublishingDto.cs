using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Haiku.DTO.Request
{
    [DataContract]
    public class HaikuPublishingDto
    {
        [DataMember(Name = "text", IsRequired = true)]
        public string Text { get; set; }
    }
}