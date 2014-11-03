using System.Runtime.Serialization;

namespace Giftable.Library.Model
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class FriendModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class AvatarModel
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}