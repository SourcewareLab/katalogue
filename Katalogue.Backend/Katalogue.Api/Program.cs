using Carter;
using Katalogue.Api;
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
}
app.UseHttpsRedirection();
app.MapCarter();

app.Run();

