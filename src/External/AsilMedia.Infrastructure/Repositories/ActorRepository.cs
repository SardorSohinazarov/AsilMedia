using AsilMedia.Domain.Entities;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsilMedia.Infrastructure.Repositories
{
    public class ActorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ActorRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Actor> InsertAsync(Actor acotr)
        {
            EntityEntry<Actor> entry = await _dbContext.AddAsync(acotr);
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

        public async Task<Film> UpdateAsync(ActorDTO actor, long id)
        {
            var storedFilm = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm is null)
                throw new FilmNotFoundException();

            //mapping
            storedFilm.FirstName = actor.FirstName;
            storedFilm. = actor.Description;
            ///...

            var entry = _dbContext.Update(storedFilm);
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
