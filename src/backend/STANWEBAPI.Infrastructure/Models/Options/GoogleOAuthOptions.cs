namespace STANWEBAPI.Infrastructure.Models.Options;

public class GoogleOAuthOptions
{
    public const string SectionName = "GoogleOAuthOptions";

    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string CallbackURL { get; set; } = string.Empty;
}