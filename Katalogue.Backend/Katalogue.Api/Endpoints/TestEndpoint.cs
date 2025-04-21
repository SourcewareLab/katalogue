using Carter;

namespace Katalogue.Api.Endpoints;

public class TestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}