using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Films;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Infrastructure.Repositories
{
    public class FilmMakerRepsitory : IFilmMakerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmMakerRepsitory(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<FilmMaker> InsertAsync(FilmMaker filmMaker)
        {
            EntityEntry<FilmMaker> entry = await _dbContext.FilmMakers.AddAsync(filmMaker);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<FilmMaker>> SelectAllAsync()
            => await _dbContext.FilmMakers.ToListAsync();

        public async Task<FilmMaker> SelectByIdAsync(long id)
        {
            var storedFilmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker is null)
                throw new FilmNotFoundException();

            return storedFilmMaker;
        }

        public async Task<FilmMaker> UpdateAsync(FilmMaker filmMaker, long id)
        {
            var storedFilmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker is null)
                throw new FilmNotFoundException();

            //mapping
            storedFilmMaker.FirstName = filmMaker.FirstName;
            storedFilmMaker.LastName = filmMaker.LastName;
            storedFilmMaker.Description = filmMaker.Description;
            ///...

            var entry = _dbContext.FilmMakers.Update(storedFilmMaker);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<FilmMaker> DeleteAsync(long id)
        {
            var storedFilmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilmMaker is null)
                throw new FilmNotFoundException();

            var entry = _dbContext.Remove(storedFilmMaker);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
