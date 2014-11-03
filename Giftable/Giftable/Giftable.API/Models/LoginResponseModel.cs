using System.Runtime.Serialization;

namespace Giftable.API.Models
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