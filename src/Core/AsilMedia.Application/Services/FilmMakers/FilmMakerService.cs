using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace AsilMedia.Application.Services.FilmMakers
{
    public class FilmMakerService : IFilmMakerService
    {
        private readonly IFilmMakerRepository _filmMakerRepository; 
        public FilmMakerService(IFilmMakerRepository filmMakerRepository)
        {
            _filmMakerRepository = filmMakerRepository;
        }

        public async Task<FilmMaker> InsertAsync(FilmMakerDTO filmMakerDTO)
        {
            var filmMaker = new FilmMaker()
            {
                Films = filmMakerDTO.Films,
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender,
                PhotoPath = filmMakerDTO.PhotoPath
            };
            return await _filmMakerRepository.InsertAsync(filmMaker);
        }

        public Task<List<FilmMaker>> SelectAllAsync()
        {
            return _filmMakerRepository.SelectAllAsync();
        }

        public Task<FilmMaker> SelectByIdAsync(long id)
        {
            return _filmMakerRepository.SelectByIdAsync(id);
        }

        public Task<FilmMaker> UpdateAsync(FilmMakerDTO filmMakerDTO, long id)
        {
            var filmMaker = new FilmMaker()
            {
                Films = filmMakerDTO.Films,
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender,
                PhotoPath = filmMakerDTO.PhotoPath
            };
            return _filmMakerRepository.UpdateAsync(filmMaker, id);
        }
        public Task<FilmMaker> DeleteAsync(long id)
        {
            return _filmMakerRepository.DeleteAsync(id);
        }
    }
}
