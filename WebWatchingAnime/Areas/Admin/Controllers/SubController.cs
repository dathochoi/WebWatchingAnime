using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel.Account;

namespace WebWatchingAnime.Areas.Admin.Controllers
{
    public class SubController : AdminController
    {
        private readonly ISubService _subService;
        public SubController(ISubService subService)
        {
            _subService = subService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _subService.GetAll();
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

                _subService.Delete(id);


                return new OkObjectResult(id);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _subService.GetById(id);
            return new OkObjectResult(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEntity(SubViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                int id = 0;
                if (vm.Id == 0)
                {
                    id = _subService.Add(vm);
                }
                else
                {
                    _subService.Update(vm);
                    id = vm.Id;
                }
                return new OkObjectResult(id);

            }
        }
    }
}