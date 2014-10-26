namespace Forum.WebApi.Models
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostDetails : PostModel
    {
        public PostDetails()
        {
            this.Comments = new HashSet<CommentModel>();
        }

        public static Expression<Func<Post, PostDetails>> FromPost
        {
            get
            {
                return x => new PostDetails()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Creator = x.Creator.Nickname,
                    PostDate = x.PostDate,
                    Comments = (from comment in x.Comments
                                select new CommentModel()
                                {
                                    Content = comment.Content,
                                    Creator = comment.Creator.Nickname,
                                    PostDate = comment.PostDate
                                }),
                    Tags = (from tag in x.Tags
                            select tag.Name)
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "creator")]
        public string Creator { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}