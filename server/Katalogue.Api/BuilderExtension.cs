using Carter;
using Katalogue.Api.Data;
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
        
        return services;
    }
}