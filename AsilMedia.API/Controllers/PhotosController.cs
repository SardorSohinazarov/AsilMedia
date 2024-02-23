using AsilMedia.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotosController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(FileModel file)
        {
            var wwwpath = _webHostEnvironment.WebRootPath;
            var filePath = Guid.NewGuid() + "-" + file.Photo.FileName;
            var fullFilePath = Path.Combine(wwwpath, "images", filePath);

            using (var stream = System.IO.File.Create(fullFilePath))
            {
                await file.Photo.CopyToAsync(stream);
            }

            return Ok(filePath);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFileAsync(string filename)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, $"images/{filename}");
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest();
            }
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/sardor", filename);
        }
    }
}
