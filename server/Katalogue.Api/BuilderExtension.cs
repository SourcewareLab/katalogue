using Carter;
using Katalogue.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Katalogue.Api;

public static class BuilderExtension
{
    public static IServiceCollection AddBuildConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddCarter();
        services.AddMediator(options => 
            options.ServiceLifetime = ServiceLifetime.Scoped);
        
        //CORS
        services.AddCors(options => 
            options.AddPolicy("development",policy => policy
                .AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(_ => true).AllowCredentials()));
        
        //DB
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresDocker"),
            o => o.UseNodaTime()));
        
        //Identity
        services.AddAuthorization();
        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<AppDbContext>();
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        });
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "Katalogue";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });
        
        return services;
    }
}