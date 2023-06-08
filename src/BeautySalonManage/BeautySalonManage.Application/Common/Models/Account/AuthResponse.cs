using System.Text.Json.Serialization;

namespace BeautySalonManage.Application.Common.Models.Account;

public class AuthResponse
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Token { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
}
