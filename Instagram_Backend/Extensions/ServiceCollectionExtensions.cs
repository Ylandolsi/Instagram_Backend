using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

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
                    builder.WithOrigins(
                            "http://localhost:5032",      
                            "http://localhost:5173")  
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

        });

    }
    
    internal static void AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(o =>
        {
            o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

            
            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                           Id = IdentityConstants.BearerScheme
                        }
                    },
                    []
                }
            };

            o.AddSecurityRequirement(securityRequirement);
        });


    }
    
    internal static void AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication(IdentityConstants.ApplicationScheme) // set cookie as default scheme
                .AddCookie(IdentityConstants.ApplicationScheme) // set cookie auth as : IdentityConstants.ApplicationScheme
                .AddBearerToken(IdentityConstants.BearerScheme); // set jwt auth as : IdentityConstants.BearerScheme
        
    }
}