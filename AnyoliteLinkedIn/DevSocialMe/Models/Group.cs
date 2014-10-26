using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevSocialMe.Models
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Messages = new HashSet<Message>();
        }

        public int GroupId { get; set; }

        [Required]
        [MinLength(5), MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(5), MaxLength(30)]
        public string Creator { get; set; }

        [Required]
        public DateTime CreationData { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}