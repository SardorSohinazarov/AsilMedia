using AsilMedia.Application.Services.Actors;
using AsilMedia.Application.Services.FilmMakers;
using AsilMedia.Application.Services.Films;
using AsilMedia.Application.Services.Genres;
using Microsoft.Extensions.DependencyInjection;

namespace AsilMedia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmMakerService, FilmMakerService>();
            services.AddScoped<IActorService, ActorService>();

            return services;
        }
    }
}
