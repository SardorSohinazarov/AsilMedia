using AsilMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IFilmMakerRepository
    {
        public Task<FilmMaker> InsertAsync(FilmMaker film);
        public Task<FilmMaker> SelectByIdAsync(long id);
        public Task<List<FilmMaker>> SelectAllAsync();
        public Task<FilmMaker> UpdateAsync(FilmMaker film, long id);
        public Task<FilmMaker> DeleteAsync(long id);
    }
}
