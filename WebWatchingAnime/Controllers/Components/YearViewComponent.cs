using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWatchingAnime.Service.Interfaces;

namespace WebWatchingAnime.Controllers.Components
{
    public class YearViewComponent : ViewComponent
    {
        private readonly IYearService yearService;
        public YearViewComponent(IYearService yearService)
        {
            this.yearService = yearService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await yearService.GetAll();
            return View(list);
        }
    }
}
