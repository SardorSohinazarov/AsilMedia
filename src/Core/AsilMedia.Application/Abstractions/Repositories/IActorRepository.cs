using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IActorRepository
    {
        public Task<Actor> InsertAsync(Actor actor);
        public Task<Actor> SelectByIdAsync(long id);
        public Task<List<Actor>> SelectAllAsync();
        public Task<List<Actor>> SelectAllAsync(List<long> ids);
        public Task<Actor> UpdateAsync(Actor actor, long id);
        public Task<Actor> DeleteAsync(long id);
    }
}
