using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects.Films;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repository;
        private readonly IGenreRepository _genreRepository;
        private readonly IActorRepository _actorRepository;

        public FilmService(
            IFilmRepository repository,
            IGenreRepository genreRepository,
            IActorRepository actorRepository)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
        }

        public async ValueTask<Film> AddAsync(FilmCreationDTO filmDTO)
        {
            List<Actor> actors = await _actorRepository.SelectAllActorsAsync(filmDTO.Actors);
            List<Genre> genres = await _genreRepository.SelectAllGenresAsync(filmDTO.Genres);

            var film = new Film()
            {
                Title = filmDTO.Title,
                Description = filmDTO.Description,
                FilmMakerId = filmDTO.FilmMakerId,
                AgeRestriction = filmDTO.AgeRestriction,
                PublishedYear = filmDTO.PublishedYear,
                PhotoPath = filmDTO.PhotoPath,
                VideoPath = filmDTO.VideoPath,
                Genres = genres,
                Actors = actors
            };

            var result = await _repository.InsertFilmAsync(film);

            return result;
        }

        public async ValueTask<List<Film>> RetrieveAllAsync()
            => await _repository.SelectAllFilmsAsync();

        public async ValueTask<Film> RetrieveByIdAsync(long id)
            => await _repository.SelectFilmByIdAsync(id);

        public async ValueTask<Film> ModifyAsync(long id, FilmModificationDTO filmDTO)
        {
            var film = new Film()
            {
                Title = filmDTO.Title,
                Description = filmDTO.Description,
                FilmMakerId = filmDTO.FilmMakerId,
                AgeRestriction = filmDTO.AgeRestriction,
                PublishedYear = filmDTO.PublishedYear,
                PhotoPath = filmDTO.PhotoPath,
                VideoPath = filmDTO.VideoPath,
            };

            var result = await _repository.UpdateFilmAsync(id, film);

            return result;
        }

        public async ValueTask<Film> RemoveAsync(long id)
            => await _repository.DeleteFilmAsync(id);
    }
}
