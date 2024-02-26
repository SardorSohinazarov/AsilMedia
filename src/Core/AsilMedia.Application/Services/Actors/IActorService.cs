using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;


namespace AsilMedia.Application.Services.Actors
{
    public interface IActorService
    {
        public Task<Actor> InsertAsync(ActorDTO filmDTO);
        public Task<Actor> SelectByIdAsync(long id);
        public Task<List<Actor>> SelectAllAsync();
        public Task<Actor> UpdateAsync(ActorDTO filmDTO, long id);
        public Task<Actor> DeleteAsync(long id);
    }
}
