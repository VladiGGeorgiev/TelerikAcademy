using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        public int UserId { get; set; }

        [Required, MinLength(6), MaxLength(30)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(30)]
        public string DisplayName { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
