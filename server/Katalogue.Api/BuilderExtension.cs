using Carter;

namespace Katalogue.Api;

public static class BuilderExtension
{
    public static IServiceCollection AddBuildConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddCarter();
        
        //CORS
        services.AddCors(options => 
            options.AddPolicy("development",policy => policy
                .AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(_ => true).AllowCredentials()));
        
        return services;
    }
}