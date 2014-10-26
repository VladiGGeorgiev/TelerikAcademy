using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using PostsCategories.Models;

namespace PostsCategories.WebApi.Models
{
    public class CategoryModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryModel>> FromCategory
        {
            get
            {
                return category => (new CategoryModel
                    {
                        Id = category.Id,

                        Name = category.Name
                    });
            }
        }
    }
}