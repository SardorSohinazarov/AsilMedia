using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Films
{
    public interface IFilmService
    {
        public Task<Film> InsertAsync(FilmDTO filmDTO);
        public Task<Film> SelectByIdAsync(long id);
        public Task<List<Film>> SelectAllAsync();
        public Task<Film> UpdateAsync(FilmDTO filmDTO, long id);
        public Task<Film> DeleteAsync(long id);
    }
}