using AsilMedia.Application.Services.Actors;
using AsilMedia.Application.Services.FilmMakers;
using Microsoft.Extensions.DependencyInjection;

namespace AsilMedia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IFilmMakerService, FilmMakerService>();
            //davom etamiz

            return services;
        }
    }
}
