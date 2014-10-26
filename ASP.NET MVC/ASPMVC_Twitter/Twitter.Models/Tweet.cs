using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tweet should have content")]
        [StringLength(140, MinimumLength = 5, ErrorMessage = "Tweet must be between {1} and {2} symbols")]
        public string Content { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<HashTag> TweetTags { get; set; }

        public Tweet()
        {
            this.TweetTags = new HashSet<HashTag>();
        }
    }
}
