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
    public class IndexController : AdminController
    {
        IAnimeService _animeService;
        public IndexController(IAnimeService animeService)
        {
            _animeService = animeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
          
            var model = _animeService.GetAllPaging(categoryId, keyword, page, pageSize);
            //if (model.Results.Count == 0)
            //    return BadRequest();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _animeService.GetById(id);
            return new OkObjectResult(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEntity(AnimeViewModel animeVm)
        {

            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {

              
                if (animeVm.Id == 0)
                {
                    _animeService.Add(animeVm);
                }
                else
                {
                    _animeService.Update(animeVm);
                }

                return new OkObjectResult(animeVm);
            }
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

                _animeService.Delete(id);


                return new OkObjectResult(id);
            }
        }
    }
}