using System;
using System.Linq;
using System.Runtime.Serialization;

namespace JustRunnerChat.Models
{
    [DataContract]
    public class ChannelJoinModel : ChannelCreateModel
    {
    }

    [DataContract]
    public class ChannelCreateModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }

    [DataContract]
    public class ChannelModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class ChannelExitModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }

    [DataContract]
    public class ChannelAddMessageModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}