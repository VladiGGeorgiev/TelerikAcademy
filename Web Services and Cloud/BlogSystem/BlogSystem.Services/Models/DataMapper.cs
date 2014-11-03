using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogSystem.Models;

namespace BlogSystem.Services.Models
{
    public static class DataMapper
    {
        public static Post CreatePostModelToPost(CreatePostModel postModel)
        {
            var post = new Post()
                {
                    Title = postModel.Title,
                    Text = postModel.Text,
                    PostDate = DateTime.Now
                };

            return post;
        }

        public static CreatePostResponseModel PostToCreatePostResponseModel(Post post)
        {
            var postResponseModel = new CreatePostResponseModel()
            {
                Title = post.Title,
                PostId = post.PostId
            };

            return postResponseModel;
        }

        public static PostModel PostToPostModel(Post post)
        {
            var postModel = new PostModel()
                {
                    Text = post.Text,
                    Title = post.Title,
                    PostId = post.PostId,
                    PostDate = post.PostDate,
                    PostedBy = post.PostedBy == null ? null : post.PostedBy.DisplayName,
                };

            foreach (var comment in post.Comments)
            {
                postModel.Comments.Add(CommentToPostCommentModel(comment));
            }

            foreach (var tag in post.Tags)
            {
                postModel.Tags.Add(tag.Name);
            }

            return postModel;
        }

        public static PostCommentModel CommentToPostCommentModel(Comment comment)
        {
            var postCommentModel = new PostCommentModel()
                {
                    Text = comment.Text,
                    PostDate = comment.PostDate,
                    CommentedBy = comment.CommentedBy == null ? null : comment.CommentedBy.DisplayName,
                };

            return postCommentModel;
        }

        public static TagModel TagToTagModel(Tag tag)
        {
            var tagModel = new TagModel()
                {
                    TagId = tag.TagId,
                    Name = tag.Name,
                    Posts = tag.Posts == null ? 0 : tag.Posts.Count
                };

            return tagModel;
        }
    }
}