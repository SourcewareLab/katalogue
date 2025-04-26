using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NodaTime;

namespace Katalogue.Api.Data.Entities;


public class Game
{
    public int GameId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required List<string> Genres { get; set; }
    public Instant ReleaseDate { get; set; }
    
    
}

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.GameId);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(2000);
        
    }
}