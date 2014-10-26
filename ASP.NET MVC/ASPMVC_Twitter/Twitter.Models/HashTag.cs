using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class HashTag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hashtag name is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Hashtag length should be between {1} and {2} symbols")]
        public string Name { get; set; }

        public virtual ICollection<Tweet> TagTweets { get; set; }

        public HashTag()
        {
            this.TagTweets = new HashSet<Tweet>();
        }
    }
}
