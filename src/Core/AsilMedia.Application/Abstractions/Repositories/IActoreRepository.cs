using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;


namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IActorRepository
    {
        public Task<Actor> CreateActorAsync(Actor actor);
        public Task<List<Actor>> GetActorAsync();
        public Task<Actor> GetActorsByIdAsync(long id);
        public Task<Actor> UpdateActorAsync(Actor actor,long id);
        public Task<Actor> DeleteActorAsync(long id);
    }
}
