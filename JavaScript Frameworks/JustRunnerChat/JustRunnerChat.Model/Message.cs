using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRunnerChat.Model
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public Channel Channel { get; set; }
    }   
}
