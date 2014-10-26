using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KendoUI_LibrarySystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}