namespace Forum.WebApi.Models
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}