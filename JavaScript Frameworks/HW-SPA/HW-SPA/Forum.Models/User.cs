namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string Nickname { get; set; }

        [Required]
        public string AuthenticationCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
