using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Actors;
using AsilMedia.Application.Services.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actor;

        public ActorController(IActorService actorService)
            => _actor = actorService;



        [HttpPost]
        public async Task<IActionResult> PostAsync(ActorDTO actorDTO )
        {
            var gerne = await _actor.InsertAsync(actorDTO);

            return Ok(gerne);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _actor.SelectAllAsync();

            return Ok(genres);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var genre = await _actor.SelectByIdAsync(id);

            return Ok(genre);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ActorDTO actorDTO, long id)
        {
            var genre = await _actor.UpdateAsync(actorDTO, id);

            return Ok(genre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var genre = await _actor.DeleteAsync(id);

            return Ok(genre);
        }
    }
}
