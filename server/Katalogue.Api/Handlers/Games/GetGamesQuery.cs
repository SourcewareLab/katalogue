using FluentResults;
using Katalogue.Api.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Katalogue.Api.Handlers.Games;

public record GetGamesQuery : IQuery<Result<List<GameDto>>>;

public class GetGamesQueryHandler : IQueryHandler<GetGamesQuery, Result<List<GameDto>>>
{
    private readonly AppDbContext _dbContext;

    public GetGamesQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async ValueTask<Result<List<GameDto>>> Handle(GetGamesQuery query, CancellationToken cancellationToken)
    {
        var gamesDto = await _dbContext.Games.AsNoTracking()
            .Select(game => GameMapper.GameToGameDto(game))  
            .ToListAsync(cancellationToken);

        return gamesDto;
    }
}