using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using PostsCategories.Models;

namespace PostsCategories.WebApi.Models
{
    public class PostModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "category")]
        public CategoryModel Category { get; set; }

        public static Expression<Func<Post, PostModel>> FromPost
        {
            get
            {
                return post => (new PostModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        Category = new CategoryModel
                        {
                            Id = post.Category.Id,

                            Name = post.Category.Name
                        }
                    });
            }
        }
    }
}