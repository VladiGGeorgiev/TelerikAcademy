using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Model;

namespace Forum.Services.Models
{
    public class ThreadDetailModel
    {
        public ThreadDetailModel()
        {
            this.Categories = new HashSet<string>();
            this.Posts = new HashSet<PostModel>();
        }

        public int ThreadId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<string> Categories { get; set; }

        public virtual ICollection<PostModel> Posts { get; set; }
    }
}