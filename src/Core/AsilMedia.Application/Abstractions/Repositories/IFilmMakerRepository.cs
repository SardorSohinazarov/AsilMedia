using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IFilmMakerRepository
    {
        public ValueTask<FilmMaker> InsertFilmMakerAsync(FilmMaker filmMaker);
        public ValueTask<List<FilmMaker>> SelectAllFilmMakersAsync();
        public ValueTask<FilmMaker> SelectFilmMakerByIdAsync(long id);
        public ValueTask<FilmMaker> UpdateFilmMakerAsync(long id, FilmMaker filmMaker);
        public ValueTask<FilmMaker> DeleteFilmMakerAsync(long id);
    }
}
