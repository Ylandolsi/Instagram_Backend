using System.Text;
using CloudinaryDotNet;
using Instagram_Backend.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Instagram_Backend.Extensions;

public static class ServiceCollectionExtensions
{
    internal static void AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {

            options.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:5173");

                });

        });

    }

    internal static void ConfigureCloudinary ( this IServiceCollection services , IConfiguration configuration ){
        Account cloudinaryAccount;
        try{
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey =configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                throw new Exception("Missing required Cloudinary configuration values");
            }

            cloudinaryAccount = new Account(
                cloud: cloudName,
                apiKey: apiKey,
                apiSecret: apiSecret
            );
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to parse Cloudinary URL: {ex.Message}");
        }
        var cloudinary = new Cloudinary(cloudinaryAccount);
        services.AddSingleton(cloudinary);

    }
    
    
    
    internal static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie().AddGoogle(options =>
        {
            var clientId = configuration["Authentication:Google:ClientId"]; // # stored in secrets.json

            if (clientId == null)
                throw new ArgumentNullException(nameof(clientId));
            
            var clientSecret = configuration["Authentication:Google:ClientSecret"];  // # stored in secrets.json
            
            if (clientSecret == null)
                throw new ArgumentNullException(nameof(clientSecret));

            options.ClientId = clientId;
            options.ClientSecret = clientSecret;
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            var jwtOptions = configuration.GetSection(JwtOptions.JwtOptionsKey)
                .Get<JwtOptions>() ?? throw new ArgumentException(nameof(JwtOptions));

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
            };

            options.Events = new JwtBearerEvents // # token received from cookie
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["ACCESS_TOKEN"];
                    return Task.CompletedTask;
                }
            };
        });
    }
}