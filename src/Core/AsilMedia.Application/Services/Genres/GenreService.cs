using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects.Genres;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
            => _repository = repository;

        public async ValueTask<Genre> AddAsync(GenreCreationDTO genreDTO)
        {
            if (String.IsNullOrWhiteSpace(genreDTO.Name))
            {
                throw new Exception("Name cannot be null or whitespace");
            }

            var genre = new Genre()
            {
                Name = genreDTO.Name,
            };

            var result = await _repository.InsertGenreAsync(genre);

            result.Name = "Tarixiy";

            return result;
        }

        public async ValueTask<List<Genre>> RetrieveAllAsync()
            => await _repository.SelectAllGenresAsync();

        public async ValueTask<Genre> RetrieveByIdAsync(long id)
            => await _repository.SelectGenreByIdAsync(id);

        public async ValueTask<Genre> ModifyAsync(long id, GenreModificationDTO genreDTO)
        {
            var genre = new Genre()
            {
                Name = genreDTO.Name,
            };

            var result = await _repository.UpdateGenreAsync(id, genre);

            return result;
        }

        public async ValueTask<Genre> RemoveAsync(long id)
            => await _repository.DeleteGenreAsync(id);
    }
}
