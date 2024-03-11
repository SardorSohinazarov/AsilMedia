using AsilMedia.Application.Services.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _permissionService.SelectAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            var permission = await _permissionService.InsertAsync(name);

            return Ok(permission);
        }
    }
}
