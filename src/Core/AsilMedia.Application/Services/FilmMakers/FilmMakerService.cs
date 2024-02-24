using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects.FilmMakers;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.FilmMakers
{
    public class FilmMakerService : IFilmMakerService
    {
        private readonly IFilmMakerRepository _repository;

        public FilmMakerService(IFilmMakerRepository repository)
            => _repository = repository;

        public async ValueTask<FilmMaker> AddAsync(FilmMakerCreationDTO filmMakerDTO)
        {
            var filmMaker = new FilmMaker()
            {
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender
            };

            var result = await _repository.InsertFilmMakerAsync(filmMaker);

            return result;
        }

        public async ValueTask<List<FilmMaker>> RetrieveAllAsync()
            => await _repository.SelectAllFilmMakersAsync();

        public async ValueTask<FilmMaker> RetrieveByIdAsync(long id)
            => await _repository.SelectFilmMakerByIdAsync(id);

        public async ValueTask<FilmMaker> ModifyAsync(long id, FilmMakerModificationDTO filmMakerDTO)
        {
            var filmMaker = new FilmMaker()
            {
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender
            };

            var result = await _repository.UpdateFilmMakerAsync(id, filmMaker);

            return result;
        }

        public async ValueTask<FilmMaker> RemoveAsync(long id)
            => await _repository.DeleteFilmMakerAsync(id);
    }
}
