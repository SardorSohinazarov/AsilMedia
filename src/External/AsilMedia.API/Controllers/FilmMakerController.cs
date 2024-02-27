using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.FilmMakers;
using AsilMedia.Application.Services.Genres;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmMakerController : ControllerBase
    {
        private readonly IFilmMakerService _filmMakerService
            ;

        public FilmMakerController(IFilmMakerService filmMakerService)
            => _filmMakerService = filmMakerService;

        [HttpPost]
        public async Task<IActionResult> PostAsync(FilmMakerDTO filmMakerDTO)
        {
            var gerne = await _filmMakerService.InsertAsync(filmMakerDTO);

            return Ok(gerne);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _filmMakerService.SelectAllAsync();

            return Ok(genres);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var genre = await _filmMakerService.SelectByIdAsync(id);

            return Ok(genre);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(FilmMakerDTO filmMakerDTO, long id)
        {
            var genre = await _filmMakerService.UpdateAsync(filmMakerDTO, id);

            return Ok(genre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var genre = await _filmMakerService.DeleteAsync(id);

            return Ok(genre);
        }
    }
}
