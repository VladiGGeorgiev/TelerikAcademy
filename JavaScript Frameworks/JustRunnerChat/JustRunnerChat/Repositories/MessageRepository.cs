using JustRunnerChat.Data;
using JustRunnerChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustRunnerChat.Repositories
{
    public class MessageRepository
    {
        public static void CreateMessage(Message message)
        {
            using (ChatContext context = new ChatContext())
            {
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }
    }
}