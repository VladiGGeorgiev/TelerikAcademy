using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User PostedBy { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
