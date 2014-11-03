using System.Collections.Generic;

namespace FbmMobileApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int StudioId { get; set; }
        public virtual Studio Studio { get; set; }
    }
}