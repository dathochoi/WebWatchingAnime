using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Context;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.Service.Mapper;
using WebWatchingAnime.Utilities.DTOs;
using WebWatchingAnime.ViewModel.ViewModel;
using WebWatchingAnime.ViewModel.ViewModel.Client;

namespace WebWatchingAnime.Service.Implementation
{
    public class AnimeService : IAnimeService
    {
        private readonly WebDbContext _context;
        public AnimeService(WebDbContext context)
        {
            this._context = context;
        }
        public int Add(AnimeViewModel anime)
        {
            var p = MapperExtend.VMToAnime(anime);
            p.CreateTime = DateTime.Now;
            p.UpdateTime = DateTime.Now;
            p.Status = true;
            p.IsEpisodes = true;
            var a =_context.Animes.Add(p);

             var xxx =_context.SaveChanges();

            return a.Entity.Id;
        }

        public void Delete(int id)
        {
            Anime p = _context.Animes.Find(id);
            if (p == null)
            {
                throw new Exception("Anime isn't exsit");

            }
            _context.Animes.Remove(p);
            _context.SaveChanges();    
        }

        public async Task<List<AnimeViewModel>> GetAll()
        {
            var listItems = await _context.Animes.ToListAsync();
            List<AnimeViewModel> listVM = new List<AnimeViewModel>();
            foreach (var item in listItems)
            {
                AnimeViewModel vm = new AnimeViewModel();
                vm = MapperExtend.AnimeToVM(item);
                listVM.Add(vm);
            }
            return listVM;
        }

        public PagedResult<AnimeViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
           var query = _context.Animes.AsQueryable();
            if (categoryId.HasValue)
            {
                //var catList = _context.AnimeCategorys.Where(x=>x.)
                //query = query.Join(_context.AnimeCategorys, a => a.Id, ac => ac.AnimeId, (a, ac) => new { Anime = a, AnimeCategory = ac });
                query = query.Where(x => x.CategoryIds.Contains(categoryId.ToString()));
            }
            
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }


            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.UpdateTime)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<AnimeViewModel> listProductVM = new List<AnimeViewModel>();
            foreach (var item in data)
            {
                var vm = MapperExtend.AnimeToVM(item);
                listProductVM.Add(vm);
            }

            var paginationSet = new PagedResult<AnimeViewModel>()
            {
                Results = listProductVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public PagedResult<AnimeClientViewModel> GetAllPagingClient(int? categoryId, string keyword, int page, int pageSize, int? year, bool anime, bool film)
        {
            var query = _context.Animes.AsQueryable();
            if (categoryId.HasValue)
            {
                //var catList = _context.AnimeCategorys.Where(x=>x.)
                //query = query.Join(_context.AnimeCategorys, a => a.Id, ac => ac.AnimeId, (a, ac) => new { Anime = a, AnimeCategory = ac });
                query = query.Where(x => x.CategoryIds.Contains(categoryId.ToString()));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if(anime == true)
            {
                query = query.Where(x => x.IsAnime == true);
            }
            if (film == true)
            {
                query = query.Where(x => x.IsAnime == false);
            }
            if (year.HasValue)
            {
                query = query.Where(x => x.YearId == year);
            }

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.UpdateTime)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<AnimeClientViewModel> listProductVM = new List<AnimeClientViewModel>();
            foreach (var item in data)
            {
                //var vm = MapperExtend.AnimeToVM(item);
                AnimeClientViewModel vm = new AnimeClientViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
              
                vm.Image = item.ImgSrc;
                //vm.EpisodeName = _context.Episodes.Where(x => x.AnimeId == item.Id).OrderByDescending(x => x.STT).FirstOrDefault().Number;
                var ep = _context.Episodes.Where(x => x.AnimeId == item.Id).OrderByDescending(x => x.STT).FirstOrDefault();
                if (ep != null)
                {
                    vm.EpisodeName = ep.Number;
                }
                vm.SubName = _context.Subs.Find(item.SubId).Name;
                listProductVM.Add(vm);
            }

            var paginationSet = new PagedResult<AnimeClientViewModel>()
            {
                Results = listProductVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public AnimeViewModel GetById(int id)
        {
            var product = _context.Animes.Find(id);
            if (product == null)
            {
                throw new Exception("Anime isn't in data.");
            }
            var vm = MapperExtend.AnimeToVM(product);
            vm.CategoryNames = new List<string>();
            foreach (var item in vm.CategoryIds)
            {
                var c = _context.Catetgories.Find(Int32.Parse(item));
                if (c == null)
                {
                    vm.CategoryNames.Add(" ");
                }
                else
                {
                    vm.CategoryNames.Add(c.Name);
                }

            }
            return vm;
        }

        public AnimeDetailsViewModel GetDetails(int id)
        {
            var product = _context.Animes.Find(id);
            if (product == null)
            {
                throw new Exception("Anime isn't in data.");
            }
            //var vm = MapperExtend.AnimeToVM(product);
            AnimeDetailsViewModel vm = new AnimeDetailsViewModel();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.OrtherName = product.OrderName;
            vm.Image = product.ImgSrc;
            vm.Details = product.Description;
            vm.MaxEps = product.EpisodesMax;

            vm.YearId = product.YearId;
            var y = _context.Year.Find(vm.YearId);
            if (y == null)
            {
                vm.YearName = " ";
            }
            else
            {
                vm.YearName = y.Name;
            }

            var sub = _context.Subs.Find(product.SubId);
            if (sub == null)
            {
                vm.SubName = " ";
            }
            else
            {
                vm.SubName = sub.Name;
            }


            vm.CategoryId = new List<string>();
            if (!String.IsNullOrEmpty(product.CategoryIds))
            {
                vm.CategoryId = product.CategoryIds.Split(",");
            }
            vm.CategoryName = new List<string>();
            foreach (var item in vm.CategoryId)
            {
                var c = _context.Catetgories.Find(Int32.Parse(item));
                if (c == null)
                {
                    vm.CategoryName.Add(" ");
                }
                else
                {
                    vm.CategoryName.Add(c.Name);
                }
            }
            vm.EpsName = new List<string>();
            vm.EpsId = new List<int>();
            var eps = _context.Episodes.Where(x => x.AnimeId == product.Id).OrderByDescending(x => x.STT).Take(3);
            if (eps != null)
            {
                foreach (var ep in eps)
                {
                    vm.EpsId.Add(ep.Id);
                    vm.EpsName.Add(ep.Number);
                }
            }

            return vm;
        }

        public void Update(AnimeViewModel anime)
        {
            var vm = MapperExtend.VMToAnime(anime);

            vm.UpdateTime = DateTime.Now;
            _context.Animes.Update(vm);
            _context.SaveChanges();
        }
    }
}
