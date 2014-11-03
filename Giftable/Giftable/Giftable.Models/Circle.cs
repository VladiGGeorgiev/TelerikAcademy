using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftable.Models
{
    public class Circle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
            
        public virtual ICollection<User> Users { get; set; }

        public Circle()
        {
            this.Users = new HashSet<User>();
        }
    }
}
