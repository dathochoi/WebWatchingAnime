using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Context;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly WebDbContext _context;
        public CategoryService(WebDbContext context)
        {
            _context = context;
        }
        public int Add(CategoryViewModel vm)
        {
            Catetgory p = new Catetgory();
            p.Name = vm.Name;
            p.Status = true;
            var a = _context.Catetgories.Add(p);
            _context.SaveChanges();
            return a.Entity.Id;
        }
        public CategoryViewModel GetById(int id)
        {
            var c = _context.Catetgories.Find(id);
            if (c == null)
            {
                throw new Exception("Category isn't in data.");
            }
            CategoryViewModel vm = new CategoryViewModel();
            vm.Id = c.Id;
            vm.Name = c.Name;
            vm.Status = c.Status;
            return vm;
        }
        public void Delete(int id)
        {
            Catetgory p = _context.Catetgories.Find(id);
            if (p == null)
            {
                throw new Exception("Category isn't exsit");

            }
            _context.Catetgories.Remove(p);
            _context.SaveChanges();
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var listItems = await _context.Catetgories.Where(x=>x.Status ==true).OrderBy(x=>x.Name).ToListAsync();
            List<CategoryViewModel> listVM = new List<CategoryViewModel>();
            foreach (var item in listItems)
            {
                CategoryViewModel vm = new CategoryViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.Status = item.Status;
                listVM.Add(vm);
            }
            return listVM;
        }

        public void Update(CategoryViewModel vm)
        {
            Catetgory p = new Catetgory();
            p.Id = vm.Id;
            p.Name = vm.Name;
            p.Status = true;
            _context.Catetgories.Update(p);
            _context.SaveChanges();
        }
    }
}
