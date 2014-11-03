using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User CommentedBy { get; set; }

        public virtual Post Post { get; set; }
    }
}
