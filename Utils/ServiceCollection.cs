using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SMS_backend.Controllers;
using SMS_backend.Models;
using System.Text;

namespace SMS_backend.Utils
{
    public class JWTSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    public static class ServiceCollection
    {
        public static IServiceCollection AddHelper(this IServiceCollection service)
        {
            service.AddScoped<AuthUserHelper>();
            service.AddScoped<JWTHelper>();
            return service;
        }
        public static IServiceCollection AddServices(this IServiceCollection service)
        {

            service.AddScoped<DepartmentService>();
            service.AddScoped<PositionService>();
            service.AddScoped<UserService>();
            return service;
        }
        public static IServiceCollection AddQueries(this IServiceCollection service)
        {
            
            service.AddScoped<DepartmentQuery>();
            service.AddScoped<PositionQuery>();
            service.AddScoped<UserQuery>();
            return service;
        }
        public static IServiceCollection AddCORS(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            return service;
        }
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "SMS API",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Bearer (token)",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
            });
            return service;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSettings = GetValidatedJWTSetting(configuration);
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Headers["Authorization"].ToString();
                            if (!string.IsNullOrEmpty(accessToken) &&
                            !accessToken.StartsWith(
                                "Bearer ",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return service;
        }
        private static JWTSetting GetValidatedJWTSetting(IConfiguration configuration)
        {
            var key = configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT key is not configured.");
            var issuer = configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT issuer ID is not configured.");
            var audience = configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT audience is not configured.");
            return new JWTSetting
            {
                Key = key,
                Issuer = issuer,
                Audience = audience
            };
        }
    }

}
