namespace Instagram_Backend.Options;

public class JwtOptions
{
    public const string JwtOptionsKey = "JwtOptions"; // ## name in appsettings.json
    
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationTimeInMinutes { get; set; }
}