namespace Forum.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostModel
    {
        public PostModel()
        {
            this.Tags = new HashSet<string>();
        }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}