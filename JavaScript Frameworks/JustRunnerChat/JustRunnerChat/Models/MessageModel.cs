using System;
using System.Runtime.Serialization;

namespace JustRunnerChat.Models
{
    [DataContract]
    public class MessageModel
    {
        [DataMember(Name = "messageId")]
        public int MessageId { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "Content")]
        public string Content { get; set; }

        [DataMember(Name = "dateTime")]
        public DateTime DateTime { get; set; }

        [DataMember(Name = "channel")]
        public string Channel { get; set; }
    }
}