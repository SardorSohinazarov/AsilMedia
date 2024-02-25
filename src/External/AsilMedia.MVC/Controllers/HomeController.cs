using AsilMedia.Application.Services.Actors;
using AsilMedia.Application.Services.FilmMakers;
using AsilMedia.Application.Services.Films;
using AsilMedia.Application.Services.Genres;
using AsilMedia.MVC.Models;
using AsilMedia.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsilMedia.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IFilmMakerService _filmMakerService;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        public HomeController(
            IFilmService filmService,
            IFilmMakerService filmMakerService,
            IActorService actorService,
            IGenreService genreService)
        {
            _filmService = filmService;
            _filmMakerService = filmMakerService;
            _actorService = actorService;
            _genreService = genreService;
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

        public async Task<IActionResult> Actor(long id)
        {
            var actor = await _actorService.RetrieveByIdAsync(id);

            return View(actor);
        }

        public async Task<IActionResult> FilmMaker(long id)
        {
            var filmMaker = await _filmMakerService.RetrieveByIdAsync(id);

            return View(filmMaker);
        }

        public async Task<IActionResult> Genre(long id)
        {
            var genre = await _genreService.RetrieveByIdAsync(id);

            return View(genre);
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
