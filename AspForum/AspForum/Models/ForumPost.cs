using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspForum.Models
{
    public class ForumPost
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserProfile Author { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EditTime { get; set; }
    }
}