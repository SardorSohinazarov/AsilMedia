using AsilMedia.Application.Abstractions;
using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Infrastructure.Repositories;
using AsilMedia.Infrastructure1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsilMedia.Infrastructure1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgress")));

            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IGenreRepository, GenreRespoitory>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IFilmMakerRepository, FilmMakerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
