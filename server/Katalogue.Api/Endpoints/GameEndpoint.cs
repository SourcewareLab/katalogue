using Carter;
using FluentResults;
using Katalogue.Api.Handlers.Games;
using Mediator;

namespace Katalogue.Api.Endpoints;

public class GameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/games", GetGames).RequireAuthorization();
        app.MapPost("/api/games", AddGame);
        
    }

    private async Task<IResult> GetGames(IMediator mediator)
    {
        Result<List<GameDto>> result = await mediator.Send(new GetGamesQuery());
        return Results.Ok(result.Value);
    }

    private async Task<IResult> AddGame(IMediator mediator, AddGameCommand request)
    {
        Result<GameDto> result = await mediator.Send(request);
        
        return Results.Ok(result.Value);
    }
}