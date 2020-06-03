using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebWatchingAnime.Service.Implementation;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _categoryService.GetAll();
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

                _categoryService.Delete(id);
                return new OkObjectResult(id);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _categoryService.GetById(id);
            return new OkObjectResult(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEntity(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {

                var id = 0;
                if (vm.Id == 0)
                {
                     id = _categoryService.Add(vm);
                }
                else
                {
                    _categoryService.Update(vm);
                    id = vm.Id;
                }
                return new OkObjectResult(id);

            }
        }
    }
}