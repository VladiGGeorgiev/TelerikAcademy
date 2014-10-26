using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspForum.ViewModel
{
    public class ForumPostViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorUsername { get; set; }
        public DateTime CreationTime { get; set; }
    }
}