using Carter;
using Katalogue.Api;
using Katalogue.Api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

//Build app
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBuildConfiguration(builder.Configuration);

//App config
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseCors("development");

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}
app.UseHttpsRedirection();
app.MapCarter();

app.Run();

