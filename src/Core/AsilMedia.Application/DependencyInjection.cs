using AsilMedia.Application.Services.Actors;
using Microsoft.Extensions.DependencyInjection;

namespace AsilMedia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            //davom etamiz

            return services;
        }
    }
}
