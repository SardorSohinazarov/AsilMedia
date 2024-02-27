using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.FilmMakers;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmMakerController : ControllerBase
    {
        private readonly IFilmMakerService _filmMakerService;

        public FilmMakerController(IFilmMakerService filmMakerService)
            => _filmMakerService = filmMakerService;

        [HttpPost]
        public async Task<IActionResult> PostAsync(FilmMakerDTO filmMakerDTO)
        {
            var filmMaker = await _filmMakerService.InsertAsync(filmMakerDTO);

            return Ok(filmMaker);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filmMakers = await _filmMakerService.SelectAllAsync();

            return Ok(filmMakers);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var filmMaker = await _filmMakerService.SelectByIdAsync(id);

            return Ok(filmMaker);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(FilmMakerDTO filmMakerDTO, long id)
        {
            var filmMaker = await _filmMakerService.UpdateAsync(filmMakerDTO, id);

            return Ok(filmMaker);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var filmMaker = await _filmMakerService.DeleteAsync(id);

            return Ok(filmMaker);
        }
    }
}
