using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRunnerChat.Model
{
    public class Channel
    {
        public Channel()
        {
            this.History = new HashSet<Message>();
            this.Users = new HashSet<User>();
        }

        public int ChannelId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Message> History { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
