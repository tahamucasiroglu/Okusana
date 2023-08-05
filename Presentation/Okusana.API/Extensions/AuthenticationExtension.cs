using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Okusana.Constants;
using System.Text;

namespace Okusana.API.Extensions
{
    static public class AuthenticationExtension
    {
        static public void AddPolicy(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(UserStatus.Admin, policy => policy.RequireRole(UserStatus.Admin));
                options.AddPolicy(UserStatus.Editor, policy => policy.RequireRole(UserStatus.Admin, UserStatus.Editor));
                options.AddPolicy(UserStatus.Member, policy => policy.RequireRole(UserStatus.Admin, UserStatus.Editor, UserStatus.Member));
            });
        }

        static public void AddJWT(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // HTTPS gerektiren durumları devre dışı bırakmak için
                options.SaveToken = true; // Token'ı kaydetmek için
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "client", // İstek oluşturan tarafın adı
                    ValidAudience = "server", // İsteğin hedeflendiği tarafın adı
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Turkcelle Bağlan Hayata Hayata Bağlan Turkcelle")) // Secret key :)
                };
            });
        }
    }
}
