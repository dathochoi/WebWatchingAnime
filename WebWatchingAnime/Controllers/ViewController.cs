using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebWatchingAnime.Service.Interfaces;

namespace WebWatchingAnime.Controllers
{
    public class ViewController : Controller
    {
        private readonly IEpisodeService _episodeService;
        public ViewController(IEpisodeService episodeService)
        {
            this._episodeService = episodeService;
        }
        // GET: View/Index/5
        public async Task<IActionResult> Index(int id)
        {
            ViewData["Id"] = id;
            ViewData["AnimeName"] = _episodeService.GetAnimeName(id);
            var list =await  _episodeService.GetAllWithAnimeId(id);
            return View(list);
        }
    }
}