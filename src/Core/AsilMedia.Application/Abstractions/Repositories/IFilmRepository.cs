using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IFilmRepository
    {
        public ValueTask<Film> InsertFilmAsync(Film film);
        public ValueTask<List<Film>> SelectAllFilmsAsync();
        public ValueTask<Film> SelectFilmByIdAsync(long id);
        public ValueTask<Film> UpdateFilmAsync(long id, Film film);
        public ValueTask<Film> DeleteFilmAsync(long id);
    }
}
