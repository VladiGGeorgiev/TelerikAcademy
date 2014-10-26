using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mustache.Services.Models
{
    [DataContract]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }
    }
}