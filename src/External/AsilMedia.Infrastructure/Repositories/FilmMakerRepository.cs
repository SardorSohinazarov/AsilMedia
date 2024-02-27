using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.FilmMakers;
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
    public class FilmMakerRepository : IFilmMakerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmMakerRepository(ApplicationDbContext _dbContext)
            => _dbContext = _dbContext;


        public async Task<FilmMaker> DeleteAsync(long id)
        {
            var filmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);
            if (filmMaker is null)
                throw new FilmMakerNotFoundException();
            var entry = _dbContext.FilmMakers.Remove(filmMaker);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;

        }

        public async Task<FilmMaker> InsertAsync(FilmMaker filmMaker)
        {
            EntityEntry<FilmMaker> entry = await _dbContext.AddAsync(filmMaker);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<FilmMaker>> SelectAllAsync()
            => await _dbContext.FilmMakers.ToListAsync();


        public async Task<FilmMaker> SelectByIdAsync(long id)
        {
            var filmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);


            if (filmMaker is null)
                throw new FilmNotFoundException();

            return filmMaker;
        }

        public async Task<FilmMaker> UpdateAsync(FilmMaker NewfilmMaker, long id)
        {

            var filmMaker = await _dbContext.FilmMakers.FirstOrDefaultAsync(x => x.Id == id);


            if (filmMaker is null)
                throw new FilmNotFoundException();

            //mapping
            filmMaker.FirstName = NewfilmMaker.FirstName;
            filmMaker.LastName = NewfilmMaker.LastName;
            filmMaker.Gender = NewfilmMaker.Gender;
            filmMaker.Films = NewfilmMaker.Films;
            filmMaker.Description = NewfilmMaker.Description;
            filmMaker.PhotoPath = NewfilmMaker.PhotoPath;
            ///...

            var entry = _dbContext.Update(filmMaker);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
