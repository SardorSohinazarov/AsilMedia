using System.Text.Json.Serialization;

using AsilMedia.Application;
using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Infrastructure;
using AsilMedia.Infrastructure.Repositories;
using AsilMedia.Infrastructure1.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectPostgres")));

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRespoitory>();
builder.Services.AddScoped<IFilmMakerRepository, FilmMakerRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
