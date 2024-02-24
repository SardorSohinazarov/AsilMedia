using AsilMedia.Application.Services.Films;
using AsilMedia.MVC.Models;
using AsilMedia.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsilMedia.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _filmService.RetrieveAllAsync();

            var viewModel = new HomeIndexViewModel()
            {
                Films = films,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Film(long id)
        {
            var film = await _filmService.RetrieveByIdAsync(id);

            return View(film);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
