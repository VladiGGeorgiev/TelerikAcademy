using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    public class ApplicationUser : User
    {
        public virtual ICollection<Tweet> UserTweets { get; set; }

        public ApplicationUser() : base()
        {
            this.UserTweets = new HashSet<Tweet>();
        }
    }
}
