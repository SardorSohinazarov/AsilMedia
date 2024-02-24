using AsilMedia.Application.DataTransferObjects.Genres;
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
        public async Task<IActionResult> PostAsync([FromBody] GenreCreationDTO genre)
            => Ok(await _genreService.AddAsync(genre));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _genreService.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await _genreService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] GenreModificationDTO genreDTO, [FromRoute] long id)
            => Ok(await _genreService.ModifyAsync(id, genreDTO));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await _genreService.RemoveAsync(id));
    }
}
