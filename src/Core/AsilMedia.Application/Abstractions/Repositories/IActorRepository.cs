using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IActorRepository
    {
        public ValueTask<Actor> InsertActorAsync(Actor actor);
        public ValueTask<List<Actor>> SelectAllActorsAsync();
        public ValueTask<List<Actor>> SelectAllActorsAsync(List<long> ids);
        public ValueTask<Actor> SelectActorByIdAsync(long id);
        public ValueTask<Actor> UpdateActorAsync(long id, Actor actor);
        public ValueTask<Actor> DeleteActorAsync(long id);
    }
}
