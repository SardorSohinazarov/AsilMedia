using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;

        public FilmService(
            IFilmRepository filmRepository,
            IActorRepository actorRepository,
            IGenreRepository genreRepository)
        {
            _filmRepository = filmRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Film> InsertAsync(FilmDTO filmDTO)
        {
            var actors = await _actorRepository.SelectAllAsync(filmDTO.Actors);
            var genres = await _genreRepository.SelectAllAsync(filmDTO.Genres);

            var film = new Film()
            {
                Title = filmDTO.Title,
                AgeRestriction = filmDTO.AgeRestriction,
                Description = filmDTO.Description,
                FilmMakerId = filmDTO.FilmMakerId,
                VideoPath = filmDTO.VideoPath,
                PhotoPath = filmDTO.PhotoPath,
                PublishedYear = filmDTO.PublishedYear,

                Actors = actors,
                Genres = genres
            };

            film = await _filmRepository.InsertAsync(film);

            return film;
        }

        public async Task<List<Film>> SelectAllAsync()
            => await _filmRepository.SelectAllAsync();

        public async Task<Film> SelectByIdAsync(long id)
            => await _filmRepository.SelectByIdAsync(id);

        public async Task<Film> UpdateAsync(FilmDTO filmDTO, long id)
        {
            var film = new Film()
            {
                Title = filmDTO.Title,
                AgeRestriction = filmDTO.AgeRestriction,

                ///...
            };

            return await _filmRepository.UpdateAsync(film, id);
        }

        public async Task<Film> DeleteAsync(long id)
            => await _filmRepository.DeleteAsync(id);
    }
}