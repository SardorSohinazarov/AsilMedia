using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects.Actors;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;

        public ActorService(IActorRepository repository)
            => _repository = repository;

        public async ValueTask<Actor> AddAsync(ActorCreationDTO actorDTO)
        {
            var actor = new Actor()
            {
                FirstName = actorDTO.FirstName,
                LastName = actorDTO.LastName,
                Description = actorDTO.Description,
                Gender = actorDTO.Gender
            };

            var result = await _repository.InsertActorAsync(actor);

            return result;
        }

        public async ValueTask<List<Actor>> RetrieveAllAsync()
            => await _repository.SelectAllActorsAsync();

        public async ValueTask<Actor> RetrieveByIdAsync(long id)
            => await _repository.SelectActorByIdAsync(id);

        public async ValueTask<Actor> ModifyAsync(long id, ActorModificationDTO actorDTO)
        {
            var actor = new Actor()
            {
                FirstName = actorDTO.FirstName,
                LastName = actorDTO.LastName,
                Description = actorDTO.Description,
                Gender = actorDTO.Gender
            };

            var result = await _repository.UpdateActorAsync(id, actor);

            return result;
        }

        public async ValueTask<Actor> RemoveAsync(long id)
            => await _repository.DeleteActorAsync(id);
    }

}
