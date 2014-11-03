using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogSystem.Services.Models
{
    public class CreatePostResponseModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }
    }
}