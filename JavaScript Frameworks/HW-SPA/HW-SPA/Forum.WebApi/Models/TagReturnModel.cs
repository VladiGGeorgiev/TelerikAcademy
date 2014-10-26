namespace Forum.WebApi.Models
{
    using Forum.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class TagReturnModel
    {
        public static Expression<Func<Tag, TagReturnModel>> FromTag
        {
            get
            {
                return x => new TagReturnModel() { Id = x.Id, Name = x.Name, PostsCount = x.Posts.Count };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int PostsCount { get; set; }
    }
}