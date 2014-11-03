using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogSystem.Models;
using System.Runtime.Serialization;

namespace BlogSystem.Services.Models
{
    [DataContract]
    public class PostCommentModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public virtual string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}