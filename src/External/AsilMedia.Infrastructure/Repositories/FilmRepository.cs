using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsilMedia.Infrastructure1.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Film> InsertAsync(Film film)
        {
            EntityEntry<Film> entry = await _dbContext.AddAsync(film);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<Film>> SelectAllAsync()
            => await _dbContext.Films.ToListAsync();

        public async Task<Film> SelectByIdAsync(long id)
        {
            var storedFilm = await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm is null)
                throw new FilmNotFoundException();

            return storedFilm;
        }

        public async Task<Film> UpdateAsync(Film film, long id)
        {
            var storedFilm = await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm is null)
                throw new FilmNotFoundException();

            //mapping
            storedFilm.Title = film.Title;
            storedFilm.Description = film.Description;
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
