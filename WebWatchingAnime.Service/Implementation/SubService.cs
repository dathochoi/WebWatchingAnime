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
using WebWatchingAnime.ViewModel.ViewModel.Account;

namespace WebWatchingAnime.Service.Implementation
{
    public class SubService : ISubService
    {
        private readonly WebDbContext _context;
        public SubService(WebDbContext context)
        {
            _context = context;
        }
        public int Add(SubViewModel s)
        {
            var p = new Sub();
            p.Name = s.Name;
            p.Status = true;
            var a = _context.Subs.Add(p);
            _context.SaveChanges();
            return a.Entity.Id;
        }
        public SubViewModel GetById(int id)
        {
            var c = _context.Subs.Find(id);
            if (c == null)
            {
                throw new Exception("Sub isn't in data.");
            }
            SubViewModel vm = new SubViewModel();
            vm.Id = c.Id;
            vm.Name = c.Name;
            vm.Status = c.Status;

            vm.Status = c.Status;
            return vm;
        }
        public void Delete(int id)
        {
            Sub p = _context.Subs.Find(id);
            if (p == null)
            {
                throw new Exception("Sub isn't exsit");

            }
            //p.Status = false;
            //_context.Subs.Update(p);
            _context.Subs.Remove(p);
            _context.SaveChanges();
        }

        public async Task<List<SubViewModel>> GetAll()
        {
            var listItems = await _context.Subs.Where(x=>x.Status ==true).OrderByDescending(x => x.Name).ToListAsync();
            List<SubViewModel> listVM = new List<SubViewModel>();
            foreach (var item in listItems)
            {
                SubViewModel vm = new SubViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.Status = item.Status;
                listVM.Add(vm);
            }
            return listVM;
        }

        public void Update(SubViewModel vm)
        {
            Sub s = new Sub();
            s.Id = vm.Id;
            s.Name = vm.Name;
            s.Status = true;
            _context.Subs.Update(s);
            _context.SaveChanges();
        }
    }
}

