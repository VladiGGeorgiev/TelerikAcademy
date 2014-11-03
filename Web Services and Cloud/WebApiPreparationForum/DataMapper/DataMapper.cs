using Forum.Model;
using Forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
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
    }
}
