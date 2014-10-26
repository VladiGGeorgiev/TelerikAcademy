using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustRunnerChat.Data;
using JustRunnerChat.Model;

namespace JustRunnerChat.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatContext context = new ChatContext();
            context.Users.Add(new User()
                {
                    Username = "Pesho",
                    AuthCode = "asdasdads",
                    Nickname = "Pesho p",
                });
            context.SaveChanges();
        }
    }
}
