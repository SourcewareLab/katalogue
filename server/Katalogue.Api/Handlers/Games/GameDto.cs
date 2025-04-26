using Katalogue.Api.Data.Entities;
using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Katalogue.Api.Handlers.Games;


[Mapper(AutoUserMappings = false)]
public static partial class GameMapper
{
    [MapProperty(nameof(Game.ReleaseDate), nameof(GameDto.ReleaseDate), Use = nameof(InstantToDateTime))]
    public static partial GameDto GameToGameDto(Game game);
    
    private static DateTime InstantToDateTime(Instant instant) => instant.ToDateTimeUtc();
}

public class GameDto
{
    public int GameId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required List<string> Genres { get; set; }
    public DateTime ReleaseDate { get; set; }
}