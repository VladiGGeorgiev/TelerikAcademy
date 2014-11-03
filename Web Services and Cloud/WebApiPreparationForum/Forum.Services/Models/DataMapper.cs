using System;
using System.Collections.Generic;
using Forum.Model;
using System.Linq;

namespace Forum.Services.Models
{
    public static class DataMapper
    {
        public static ThreadModel ThreadToThreadModel(Thread thread)
        {
            var threadModel = new ThreadModel()
                {
                    Content = thread.Content,
                    DateCreated = thread.DateCreated,
                    ThreadId = thread.ThreadId,
                    Title = thread.Title
                };

            return threadModel;
        }

        public static ThreadDetailModel ThreadToThreadDetailModel(Thread thread)
        {
            var threadModel = new ThreadDetailModel()
            {
                Content = thread.Content,
                DateCreated = thread.DateCreated,
                ThreadId = thread.ThreadId,
                Title = thread.Title,
            };

            foreach (var category in thread.Categories)
            {
                threadModel.Categories.Add(category.Name);
            }

            foreach (var post in thread.Posts)
            {
                var postModel = new PostModel()
                    {
                        Content = post.Content,
                        PostDate = post.PostDate,
                        PostedBy = post.Author.Nickname
                    };

                double averageVote = 0;
                double sumVotes = 0;
                foreach (var vote in post.Votes)
                {
                    sumVotes += vote.Value;
                }
                averageVote = sumVotes/post.Votes.Count;
                postModel.Rating = averageVote.ToString();
                threadModel.Posts.Add(postModel);
            }

            threadModel.CreatedBy = thread.User == null ? null : thread.User.Nickname;

            return threadModel;
        } 

        public static Thread ThreadModelToThread(ThreadModel threadModel)
        {
            var thread = new Thread()
                {
                    Content = threadModel.Content,
                    DateCreated = threadModel.DateCreated,
                    ThreadId = threadModel.ThreadId,
                    Title = threadModel.Title
                };

            return thread;
        }

        public static PostModel PostToPostModel(Post post)
        {
            PostModel postModel = new PostModel()
                {
                    Content = post.Content,
                    PostDate = post.PostDate,
                    PostedBy = post.Author.Nickname
                };

            double averageVote = 0;
            double sumVotes = 0;
            foreach (var vote in post.Votes)
            {
                sumVotes += vote.Value;
            }

            averageVote = sumVotes / post.Votes.Count;
            postModel.Rating = averageVote.ToString();

            return postModel;
        }
    }
}
