using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Context;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Service.Interfaces;
using WebWatchingAnime.Utilities.DTOs;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Implementation
{
    public class EpisodeService : IEpisodeService
    {
        private readonly WebDbContext _context;
        public EpisodeService(WebDbContext context)
        {
            _context = context;
        }
        public int Add(EpisodeViewModel ep)
        {
            var p = new Episode();
            p.AnimeId = ep.AnimeId;
            p.Number = ep.Number;
            p.Src = ep.Src;
            p.STT = ep.STT;
            var a = _context.Episodes.Add(p);
            _context.SaveChanges();
            return a.Entity.Id;
        }

        public void Delete(int id)
        {
            Episode p = _context.Episodes.Find(id);
            if (p == null)
            {
                throw new Exception("Episode isn't exsit");

            }
            _context.Episodes.Remove(p);
            _context.SaveChanges();
        }

        public PagedResult<EpisodeViewModel> GetAllPaging(int animeId, string keyword, int page, int pageSize)
        {
            var query = _context.Episodes.Where(x => x.AnimeId == animeId);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Number.Contains(keyword));
            }

            int totalRow = query.Count();

            query = query.OrderBy(x => x.STT)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<EpisodeViewModel> listEpsVM = new List<EpisodeViewModel>();
            foreach (var item in data)
            {
                //var vm = MapperExtend.AnimeToVM(item);
                EpisodeViewModel vm = new EpisodeViewModel();
                vm.Id = item.Id;
                vm.AnimeId = item.AnimeId;
                vm.Number = item.Number;
                vm.Src = item.Src;
                vm.STT = item.STT;
               
                listEpsVM.Add(vm);
            }
            var paginationSet = new PagedResult<EpisodeViewModel>()
            {
                Results = listEpsVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public async Task<List<EpisodeViewModel>> GetAllWithAnimeId(int animeId)
        {
            Anime a = await _context.Animes.FindAsync(animeId);
            if (a == null)
            {
                throw new Exception("Animes isn't exsit");

            }
            List<Episode> list =await  _context.Episodes.Where(x => x.AnimeId == a.Id).ToListAsync();
            List<EpisodeViewModel> listvm = new List<EpisodeViewModel>();
            foreach (var item in list)
            {
                EpisodeViewModel vm = new EpisodeViewModel();
                vm.Id = item.Id;
                vm.AnimeId = item.AnimeId;
                vm.Src = item.Src;
                vm.Number = item.Number;
                vm.STT = item.STT;
                listvm.Add(vm);
            }
            return listvm;

        }

        public EpisodeViewModel GetById(int id)
        {
            var ep = _context.Episodes.Find(id);
            if (ep == null)
            {
                throw new Exception("Episode isn't in data.");
            }
            EpisodeViewModel vm = new EpisodeViewModel();
            vm.Id = ep.Id;
            vm.AnimeId = ep.AnimeId;
            vm.Number = ep.Number;
            vm.Src = ep.Src;
            vm.STT = ep.STT;
            return vm;
        }


        public string GetAnimeName(int AnimeId)
        {
            var item = _context.Animes.Find(AnimeId);
            if (item == null){
                throw new Exception("Animes isn't exsit");
            }
            return item.Name;
        }

        public void Update(EpisodeViewModel ep)
        {
            Episode p = new Episode();
            p.Id = ep.Id;
            p.Number = ep.Number;
            p.Src = ep.Src;
            p.STT = ep.STT;
            _context.Episodes.Update(p);
            _context.SaveChanges();
        }
    }
}
