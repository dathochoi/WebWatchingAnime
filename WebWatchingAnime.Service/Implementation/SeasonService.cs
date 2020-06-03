using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Context;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Implementation
{
    public class SeasonService : ISeasonService
    {
        private readonly WebDbContext _context;
        public SeasonService(WebDbContext context)
        {
            _context = context;
        }
        public int Add(SeasonViewModel vm)
        {
            var p = new Season();
            p.Name = vm.Name;
            var a = _context.Seasons.Add(p);
            _context.SaveChanges();
            return a.Entity.Id;
        }

        public void Delete(int id)
        {
            Season p = _context.Seasons.Find(id);
            if (p == null)
            {
                throw new Exception("Season isn't exsit");

            }
            _context.Seasons.Remove(p);
            _context.SaveChanges();
        }

        public async Task<List<SeasonViewModel>> GetAll()
        {
            var listItems = await _context.Seasons.ToListAsync();
            List<SeasonViewModel> listVM = new List<SeasonViewModel>();
            foreach (var item in listItems)
            {
                SeasonViewModel vm = new SeasonViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                listVM.Add(vm);
            }
            return listVM;
        }

        public void Update(SeasonViewModel vm)
        {
            Season p = new Season();
            p.Id = vm.Id;
            p.Name = vm.Name;
            _context.Seasons.Update(p);
            _context.SaveChanges();
        }
    }
}
