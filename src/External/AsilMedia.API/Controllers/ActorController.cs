using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Actors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateActor(ActorDTO actor) 
        {
            var Newactor = await _actorService.InsertAsync(actor);
            return Ok(Newactor);
        }
        [HttpGet]
        public async Task<IActionResult> GetActor() 
        {
            var Newactor = await _actorService.SelectAllAsync();
            return Ok(Newactor);
        }
        [HttpGet]
        public async Task<IActionResult> GetActorById(long id) 
        {
            var Newactor = await _actorService.SelectByIdAsync(id);
            return Ok(Newactor);    
        }


        [HttpPatch]
        public async Task<IActionResult> Update(ActorDTO actor, long id) 
        {
            var Newactor = await _actorService.UpdateAsync(actor, id);
            return Ok(Newactor);    
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id) 
        {
            var Newactor  = await _actorService.DeleteAsync(id);
            return Ok(Newactor);
        }
    }
}
