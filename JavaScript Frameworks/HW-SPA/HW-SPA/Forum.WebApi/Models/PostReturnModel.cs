namespace Forum.WebApi.Models
{
    using Forum.Models;
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostReturnModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        public static PostReturnModel CreateModel(Post post)
        {
            PostReturnModel model = new PostReturnModel()
            {
                Id = post.Id,
                Title = post.Title
            };

            return model;
        }
    }
}