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

namespace WebWatchingAnime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeService _animeService;

        public HomeController(IAnimeService _animeServce)
        {
            this._animeService = _animeServce;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var vm = _animeService.GetById(Id);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {

            var model = _animeService.GetAllPagingClient(categoryId, keyword, page, pageSize);
            return new OkObjectResult(model);
        }


    }
}
