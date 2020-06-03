using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Context;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Implementation
{
    public class AnimeCategoryService : IAnimeCategoryService
    {
        private readonly WebDbContext _context;
        public AnimeCategoryService(WebDbContext context)
        {
            _context = context;
        }
        public AnimeCategoryViewModel Add(AnimeCategoryViewModel vm)
        {
            AnimeCategory p = new AnimeCategory();
            p.CategoryId = vm.CategoryId;
            p.AnimeId = vm.AnimeId;
            var a = _context.AnimeCategorys.Add(p);
           
            _context.SaveChanges();
            return vm;
        }

        public void Delete(AnimeCategoryViewModel vm)
        {
            AnimeCategory p = _context.AnimeCategorys.Where(x => x.AnimeId == vm.AnimeId && x.CategoryId == vm.CategoryId).FirstOrDefault();
            if (p == null)
            {
                throw new Exception("AnimeCategory isn't exsit");

            }
            _context.AnimeCategorys.Remove(p);
            _context.SaveChanges();
        }

        public async Task<List<AnimeCategoryViewModel>> GetAll()
        {
            var listItems = await _context.AnimeCategorys.ToListAsync();
            List<AnimeCategoryViewModel> listVM = new List<AnimeCategoryViewModel>();
            foreach (var item in listItems)
            {
                AnimeCategoryViewModel vm = new AnimeCategoryViewModel();
                vm.AnimeId = item.AnimeId;
                vm.CategoryId = item.CategoryId;
                listVM.Add(vm);
            }
            return listVM;
        }

        //public void Update(AnimeCategoryViewModel year)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
