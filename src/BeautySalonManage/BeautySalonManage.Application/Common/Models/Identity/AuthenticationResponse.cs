using System.Text.Json.Serialization;

namespace BeautySalonManage.Application.Common.Models.Users
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
