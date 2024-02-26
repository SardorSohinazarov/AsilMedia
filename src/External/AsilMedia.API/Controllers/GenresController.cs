using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Genres;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
            => _genreService = genreService;

        [HttpPost]
        public async Task<IActionResult> PostAsync(GenreDTO genreDTO)
        {
            var gerne = await _genreService.InsertAsync(genreDTO);

            return Ok(gerne);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.SelectAllAsync();

            return Ok(genres);
        }
    }
}
