using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSystem.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(15)]
        public string ISBN { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(100)]
        public string WebSite { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> DropDownItems { get; set; }
    }
}