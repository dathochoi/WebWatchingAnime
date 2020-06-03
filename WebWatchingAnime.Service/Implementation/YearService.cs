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
    public class YearService : IYearService
    {
        private readonly WebDbContext _context;
        public YearService(WebDbContext context)
        {
            _context = context;
        }
        public int Add(YearViewModel year)
        {
            var p = new Year();
            p.Name = year.Name;
            p.Status = true;
            var a = _context.Year.Add(p);
            _context.SaveChanges();
            return a.Entity.Id;
        }
        public YearViewModel GetById(int id)
        {
            var c = _context.Year.Find(id);
            if (c == null)
            {
                throw new Exception("Year isn't in data.");
            }
            YearViewModel vm = new YearViewModel();
            vm.Id = c.Id;
            vm.Name = c.Name;
            
            vm.Status = c.Status;
            return vm;
        }
        public void Delete(int id)
        {
            Year p = _context.Year.Find(id);
            if (p == null)
            {
                throw new Exception("Year isn't exsit");

            }
             _context.Year.Remove(p);
            //p.Status = false;
           // _context.Year.Update(p);
            _context.SaveChanges();
        }

        public async Task<List<YearViewModel>> GetAll()
        {
            var listItems = await _context.Year.Where(x=>x.Status==true).OrderByDescending(x => x.Name).ToListAsync();
            List<YearViewModel> listVM = new List<YearViewModel>();
            foreach (var item in listItems)
            {
                YearViewModel vm = new YearViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.Status = item.Status;
                listVM.Add(vm);
            }
            return listVM;
        }

        public void Update(YearViewModel vm)
        {
            Year year = new Year();
            year.Id = vm.Id;
            year.Name = vm.Name;
            year.Status = true;
            _context.Year.Update(year);
            _context.SaveChanges();
        }
    }
}
