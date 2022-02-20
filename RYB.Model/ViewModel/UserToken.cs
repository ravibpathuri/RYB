using System.Text.Json.Serialization;

namespace RYB.Model.ViewModel;

public class UserToken
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Username { get; set; } = default!;

    [JsonIgnore]
    public string PasswordHash { get; set; } = default!;

    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; } = default!;
}

