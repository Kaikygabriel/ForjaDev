using System.Text;
using ForjaDev.Application.Category.UseCases.Command.Command;
using ForjaDev.Application.Member.UseCases.Command.Handler;
using ForjaDev.Application.Services;
using ForjaDev.Domain.BackOffice.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ForjaDev.Application.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddMediatR
            (x => x.RegisterServicesFromAssembly(typeof(RegisterMemberHandler).Assembly));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IServiceUser,ServiceUser>();
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new()
            {
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                ClockSkew = TimeSpan.Zero
            };
        });
        services.AddAuthorization();

        return services;
    }
}