using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Okusana.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Okusana.API.Extensions
{
    static public class AuthenticationExtension
    {
        //static public void AddCookies(this WebApplicationBuilder builder)
        //{
        //    IConfigurationSection CookieSettings = builder.Configuration.GetSection("CookieSettings");
        //    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //    .AddCookie(options =>
        //    {
        //        options.LoginPath = CookieSettings["LoginPath"]; // Kullanıcı giriş yapmadıysa yönlendirilecek yol
        //        options.LogoutPath = CookieSettings["LogoutPath"]; // Çıkış yapılacak yol
        //        options.ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(CookieSettings["ExpireTimeSpan"])); // Cookie süresi (30 dakika)
        //    });
        //}

        static public void AddPolicy(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(UserStatus.Admin, policy => policy.RequireRole(UserStatus.Admin));
                options.AddPolicy(UserStatus.Editor, policy => policy.RequireRole(UserStatus.Admin, UserStatus.Editor));
                options.AddPolicy(UserStatus.Member, policy => policy.RequireRole(UserStatus.Admin, UserStatus.Editor, UserStatus.Member));
            });
        }

        static public void AddCookies(this WebApplicationBuilder builder)
        {

            IConfigurationSection CookieSettings = builder.Configuration.GetSection("CookieSettings");
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = CookieSettings["LoginPath"]; // Kullanıcı giriş yapmadıysa yönlendirilecek yol
               options.LogoutPath = CookieSettings["LogoutPath"]; // Çıkış yapılacak yol
               options.ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(CookieSettings["ExpireTimeSpan"])); // Cookie süresi (30 dakika)
           });
        }

        static public void AddJWT(this WebApplicationBuilder builder)
        {
            IConfigurationSection JwtSettings = builder.Configuration.GetSection("JwtSettings");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//biri çalışıyor ama hangisi
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.RequireAuthenticatedSignIn = Convert.ToBoolean(JwtSettings["RequireAuthenticatedSignIn"]);
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = Convert.ToBoolean(JwtSettings["RequireHttpsMetadata"]); // HTTPS gerektiren durumları devre dışı bırakmak için
                options.SaveToken = Convert.ToBoolean(JwtSettings["SaveToken"]); // Token'ı kaydetmek için

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = Convert.ToBoolean(JwtSettings["ValidateIssuer"]),
                    ValidateAudience = Convert.ToBoolean(JwtSettings["ValidateAudience"]),
                    ValidateIssuerSigningKey = Convert.ToBoolean(JwtSettings["ValidateIssuerSigningKey"]),
                    ValidIssuer = JwtSettings["ValidIssuer"], // İstek oluşturan tarafın adı
                    ValidAudience = JwtSettings["ValidAudience"], // İsteğin hedeflendiği tarafın adı
                    ValidateLifetime = Convert.ToBoolean(JwtSettings["ValidateLifetime"]),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["IssuerSigningKey"] ?? "")) // Secret key :)  uyarı vermesin diye ?? var zaten appsettings almazsa uzunluktan dolayı burası hata verecek 
                };
            });
        }

        static public string GenerateJwtToken(this List<Claim> claims)
        {
            

            var secretKey = Encoding.UTF8.GetBytes("Turkcelle Bağlan Hayata Hayata Bağlan Turkcelle");
            var issuer = "client";
            var audience = "server";
            var expires = DateTime.UtcNow.AddMinutes(30);
            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return "Bearer " + tokenHandler.WriteToken(tokenOptions);
        }
    }
}
