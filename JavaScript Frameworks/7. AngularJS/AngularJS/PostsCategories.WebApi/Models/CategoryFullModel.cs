using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using PostsCategories.Models;

namespace PostsCategories.WebApi.Models
{
    public class CategoryFullModel : CategoryModel
    {
        [DataMember(Name = "posts")]
        public IEnumerable<PostModel> Posts { get; set; }

        public static Expression<Func<Category, CategoryFullModel>> FromCategory
        {
            get
            {
                return category => (new CategoryFullModel
                {
                    Id = category.Id,

                    Name = category.Name,

                    Posts = category.Posts.Select(post => new PostModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        Category = new CategoryModel
                        {
                            Id = category.Id,

                            Name = category.Name
                        }
                    })
                });
            }
        }
    }
}