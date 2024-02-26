using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Enums;

namespace AsilMedia.Application.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository  _actorService;
        public ActorService(IActorRepository actorService)
        {
            _actorService = actorService;
        }

        public async Task<Actor> DeleteAsync(long id)
        => await _actorService.DeleteActorAsync(id);

        public async Task<List<Actor>> SelectAllAsync()
        => await _actorService.GetActorAsync();

        public async Task<Actor> SelectByIdAsync(long id)
        => await _actorService.GetActorsByIdAsync(id);

        public async Task<Actor> InsertAsync(ActorDTO actorDTO)
        {
            Actor actor = new Actor
            {
                FirstName = actorDTO.FirstName,
                LastName = actorDTO.LastName,
                Description = actorDTO.Description,
                PhotoPath = actorDTO.PhotoPath,
                Gender = actorDTO.Gender

            };
            return await _actorService.CreateActorAsync(actor);
        }

        public async Task<Actor> UpdateAsync(ActorDTO actorDTO, long id)
        {
            Actor actor = new Actor
            {
                FirstName = actorDTO.FirstName,
                LastName = actorDTO.LastName,
                Description = actorDTO.Description,
                PhotoPath = actorDTO.PhotoPath,
                Gender = actorDTO.Gender

            };
            return await _actorService.UpdateActorAsync(actor,id);
        }
    }
}
