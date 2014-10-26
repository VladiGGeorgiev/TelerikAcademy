using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalExam.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}