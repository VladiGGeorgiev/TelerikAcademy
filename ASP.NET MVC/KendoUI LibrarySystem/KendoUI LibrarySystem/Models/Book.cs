using System.ComponentModel.DataAnnotations;
using KendoUI_LibrarySystem.Models;

namespace KendoUI_LibrarySystem.Models
{
    public class Book
    {
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

        public virtual Category Category { get; set; }
    }
}
