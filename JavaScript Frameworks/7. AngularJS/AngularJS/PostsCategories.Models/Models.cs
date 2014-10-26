using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsCategories.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
    }
}
