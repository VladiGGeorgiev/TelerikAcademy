using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRunnerChat.Model
{
    public class User
    {
        public User()
        {
            this.Channels = new HashSet<Channel>();
        }

        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        public string Nickname { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public string AvatarLink { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
