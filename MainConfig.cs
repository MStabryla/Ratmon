using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Ratmon;

public class MainConfig
{
    public required string DbPath { get; set; }
    public required JwtConfig JWT { get; set; }
}

public class JwtConfig
{
    public required string Secret { get; set; }
    public required string Authority { get; set; }
    public required string Audience { get; set; }
    public required string ValidIssuer { get; set; }
    public required string ValidAudience { get; set; }
    public required double ExpirationTime { get; set; }
}
