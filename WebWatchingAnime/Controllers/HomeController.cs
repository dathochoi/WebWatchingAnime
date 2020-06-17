using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebWatchingAnime.Models;
using WebWatchingAnime.Service.Implementation;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel.Client;

namespace WebWatchingAnime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeService _animeService;

        public HomeController(IAnimeService _animeServce)
        {
            this._animeService = _animeServce;
        }

        public IActionResult Index([FromQuery]bool? Animes, [FromQuery]bool? Films, [FromQuery]int? Category, [FromQuery]int? Year, [FromQuery]string? TextSearch)
        {
            SearchViewModel s = new SearchViewModel();
            if (Animes.HasValue)
            {
                s.Animes = 1;
            }
            if (Films.HasValue)
            {
                s.Films = 1;
            }
            if (Category.HasValue)
            {
                s.CategoryId = Category.Value;
            }
            if (Year.HasValue)
            {
                s.YearId = Year.Value;
            }
            if (!string.IsNullOrEmpty(TextSearch))
            {
                s.TextSearch = TextSearch;
            }
            else
            {
                s.TextSearch = "z00000zzzzz";
            }
            return View(s);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var vm = _animeService.GetDetails(Id);
            return View(vm);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId,int? year, bool anime, bool film, string keyword, int page, int pageSize)
        {

            var model = _animeService.GetAllPagingClient(categoryId, keyword, page, pageSize, year, anime,film);
            return new OkObjectResult(model);
        }


    }
}
