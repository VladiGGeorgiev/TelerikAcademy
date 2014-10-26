namespace Forum.WebApi.Models
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "creator")]
        public string Creator { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}