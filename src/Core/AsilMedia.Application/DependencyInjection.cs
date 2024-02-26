using AsilMedia.Application.Services.Genres;
using Microsoft.Extensions.DependencyInjection;

namespace AsilMedia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
