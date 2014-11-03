using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Services.Models
{
    public class ThreadModel
    {
        public int ThreadId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}