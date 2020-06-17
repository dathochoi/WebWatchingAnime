using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Controllers.Components
{
    public class Category2ViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public Category2ViewComponent(ICategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _categoryService.GetAll();
            return View(list);
        }
    }
}
