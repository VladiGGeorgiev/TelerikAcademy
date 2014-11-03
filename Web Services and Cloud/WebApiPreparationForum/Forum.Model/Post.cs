using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class Post
    {
        public Post()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User Author { get; set; }

        public virtual Thread Thread { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
