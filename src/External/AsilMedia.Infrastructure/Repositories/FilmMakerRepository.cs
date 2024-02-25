using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class FilmMakerRepository : IFilmMakerRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmMakerRepository(ApplicationDbContext context)
            => _context = context;

        public async ValueTask<FilmMaker> InsertFilmMakerAsync(FilmMaker filmMaker)
        {
            var entry = await _context.AddAsync(filmMaker);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<FilmMaker> SelectFilmMakerByIdAsync(long id)
        {
            var storedFilmMaker = await _context.FilmMakers
                .Include(x => x.Films)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker == null)
                throw new Exception($"FilmMaker {id} was not found.");

            return storedFilmMaker;
        }

        public async ValueTask<List<FilmMaker>> SelectAllFilmMakersAsync()
            => await _context.FilmMakers
                .AsNoTracking()
                .ToListAsync();

        public async ValueTask<FilmMaker> UpdateFilmMakerAsync(long id, FilmMaker filmMaker)
        {
            var storedFilmMaker = await _context.FilmMakers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker == null)
                throw new Exception($"FilmMaker {id} was not found.");

            storedFilmMaker.FirstName = filmMaker.FirstName;
            storedFilmMaker.LastName = filmMaker.LastName;
            storedFilmMaker.Gender = filmMaker.Gender;
            storedFilmMaker.Description = filmMaker.Description;
            storedFilmMaker.PhotoPath = filmMaker.PhotoPath;
            storedFilmMaker.UpdatedAt = DateTime.Now;

            var entry = _context.Update(storedFilmMaker);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<FilmMaker> DeleteFilmMakerAsync(long id)
        {
            var storedFilmMaker = await _context.FilmMakers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker == null)
                throw new Exception($"FilmMaker {id} was not found.");

            var entry = _context.Remove(storedFilmMaker);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
