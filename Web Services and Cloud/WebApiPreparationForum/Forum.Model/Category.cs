using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
