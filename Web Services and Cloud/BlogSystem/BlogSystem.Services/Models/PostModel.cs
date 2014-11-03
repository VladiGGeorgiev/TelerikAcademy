using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BlogSystem.Models;

namespace BlogSystem.Services.Models
{
    [DataContract]
    public class PostModel
    {
        public PostModel()
        {
            this.Tags = new HashSet<string>();
            this.Comments = new HashSet<PostCommentModel>();
        }

        [DataMember(Name = "id")]
        public int PostId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public virtual ICollection<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public virtual ICollection<PostCommentModel> Comments { get; set; }
    }
}