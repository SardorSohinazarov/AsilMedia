using AsilMedia.Application.DataTransferObjects.Actors;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Actors
{
    public interface IActorService
    {
        public ValueTask<Actor> AddAsync(ActorCreationDTO actorDTO);
        public ValueTask<List<Actor>> RetrieveAllAsync();
        public ValueTask<Actor> RetrieveByIdAsync(long id);
        public ValueTask<Actor> ModifyAsync(long id, ActorModificationDTO actorDTO);
        public ValueTask<Actor> RemoveAsync(long id);
    }
}
