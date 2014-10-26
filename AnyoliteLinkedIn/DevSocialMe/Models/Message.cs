using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevSocialMe.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}