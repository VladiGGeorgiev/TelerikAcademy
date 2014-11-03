using System.Runtime.Serialization;

namespace Giftable.Library.Model
{
    [DataContract]
    public class LoginResponseModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}