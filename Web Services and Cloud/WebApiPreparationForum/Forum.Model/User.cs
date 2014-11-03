using System.Collections.Generic;

namespace Forum.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public ICollection<Thread> Threads { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
