using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Areas.Admin.Controllers
{
    public class EpisodeController : AdminController
    {
        private readonly IEpisodeService _episodeService;
        public EpisodeController(IEpisodeService _episodeService)
        {
            this._episodeService = _episodeService;
        }
        [HttpGet]
        public IActionResult Index(int Id)
        {
            ViewData["Id"] = Id;
            ViewData["AnimeName"] = _episodeService.GetAnimeName(Id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int AnimeId)
        {
            var model = await _episodeService.GetAllWithAnimeId(AnimeId);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {

                _episodeService.Delete(id);


                return new OkObjectResult(id);
            }
        }
        [HttpGet]
        public IActionResult GetAllPaging( int animeId, string keyword, int page, int pageSize)
        {
            var model = _episodeService.GetAllPaging(animeId, keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _episodeService.GetById(id);
            return new OkObjectResult(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEntity(EpisodeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {

                if (vm.Id == 0)
                {
                    _episodeService.Add(vm);
                }
                else
                {
                    _episodeService.Update(vm);
                }
                return new OkObjectResult(vm);

            }
        }
    }
}