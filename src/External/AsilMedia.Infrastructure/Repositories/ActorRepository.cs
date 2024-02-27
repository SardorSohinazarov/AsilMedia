using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Actors;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsilMedia.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ActorRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Actor> InsertAsync(Actor actor)
        {
            EntityEntry<Actor> entry = await _dbContext.AddAsync(actor);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<Actor>> SelectAllAsync()
            => await _dbContext.Actors.ToListAsync();

        public async Task<Actor> SelectByIdAsync(long id)
        {
            var storedFilm = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm is null)
                throw new FilmNotFoundException();

            return storedFilm;
        }

        public async Task<Actor> UpdateAsync(Actor actor, long id)
        {
            var storedActor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (storedActor is null)
                throw new ActorNotFoundException();

            storedActor.FirstName = actor.FirstName;
            storedActor.LastName = actor.LastName;

            var entry = _dbContext.Update(storedActor);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Film> DeleteAsync(long id)
        {
            var storedFilm = await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm is null)
                throw new FilmNotFoundException();

            var entry = _dbContext.Remove(storedFilm);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
