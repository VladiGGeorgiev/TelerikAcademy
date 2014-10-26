using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BookSystem.Models;

namespace BookSystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}