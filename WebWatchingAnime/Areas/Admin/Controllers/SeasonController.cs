using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebWatchingAnime.Service.Implementation;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Areas.Admin.Controllers
{
    public class SeasonController : AdminController
    {
        private readonly SeasonService _seasonService;
        public SeasonController(SeasonService _seasonService)
        {
            this._seasonService = _seasonService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _seasonService.GetAll();
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

                _seasonService.Delete(id);


                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult SaveEntity(SeasonViewModel vm)
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
                    _seasonService.Add(vm);
                }
                else
                {
                    _seasonService.Update(vm);
                }
                return new OkObjectResult(vm);

            }
        }
    }
}