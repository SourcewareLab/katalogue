using FluentResults;
using Katalogue.Api.Data;
using Katalogue.Api.Data.Entities;
using Mediator;
using NodaTime.Extensions;

namespace Katalogue.Api.Handlers.Games;

public record AddGameCommand(string Title, string Description, List<string> Genres, DateTime ReleaseDate) 
    : ICommand<Result<GameDto>>;

public class AddGameCommandHandler : ICommandHandler<AddGameCommand, Result<GameDto>>
{
    private readonly AppDbContext _dbContext;

    public AddGameCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask<Result<GameDto>> Handle(AddGameCommand command, CancellationToken cancellationToken)
    {
        var gameToAdd = new Game
        {
            Title = command.Title,
            Description = command.Description,
            Genres = command.Genres,
            ReleaseDate = command.ReleaseDate.ToUniversalTime().ToInstant()
        };
        
        await _dbContext.Games.AddAsync(gameToAdd, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return GameMapper.GameToGameDto(gameToAdd);
    }
}
