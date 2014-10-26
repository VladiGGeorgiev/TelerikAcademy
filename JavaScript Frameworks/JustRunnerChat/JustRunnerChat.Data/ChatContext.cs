using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustRunnerChat.Model;

namespace JustRunnerChat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("JustRunnerChatDb")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
