using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Mapper
{
    public static class MapperExtend
    {
        public static AnimeViewModel AnimeToVM(Anime Anime)
        {
            AnimeViewModel vm = new AnimeViewModel();
            vm.Id = Anime.Id;
            vm.Name = Anime.Name;
            vm.OrderName = Anime.OrderName;
            vm.ImgSrc = Anime.ImgSrc;
            vm.Description = Anime.Description;
           // vm.Node = Anime.Node;
            vm.SrcTrailer = Anime.SrcTrailer;
            vm.EpisodesMax = Anime.EpisodesMax;
            vm.IsAnime = Anime.IsAnime;
            vm.IsEpisodes = Anime.IsEpisodes;
            vm.CreateTime = Anime.CreateTime;
            vm.UpdateTime = Anime.UpdateTime;
            vm.SeasonId = Anime.SeasonId;
            vm.SeasonName = Anime.SeasonName;
            vm.YearId = Anime.YearId;
            vm.SubId = Anime.SubId;
            // vm.CategoryIds = Anime.CategoryIds;
            if (!String.IsNullOrEmpty(Anime.CategoryIds)) 
            {
                vm.CategoryIds = Anime.CategoryIds.Split(",");
            }
            return vm;
        }

        public static Anime VMToAnime(AnimeViewModel Anime)
        {
            Anime vm = new Anime();
            vm.Id = Anime.Id;
            vm.Name = Anime.Name;
            vm.OrderName = Anime.OrderName;
            vm.ImgSrc = Anime.ImgSrc;
            vm.Description = Anime.Description;
            // vm.Node = Anime.Node;
            vm.SrcTrailer = Anime.SrcTrailer;
            vm.EpisodesMax = Anime.EpisodesMax;
            vm.IsAnime = Anime.IsAnime;
            vm.IsEpisodes = Anime.IsEpisodes;
            vm.CreateTime = Anime.CreateTime;
            vm.UpdateTime = Anime.UpdateTime;
            vm.SeasonId = Anime.SeasonId;
            vm.SeasonName = Anime.SeasonName;
            vm.YearId = Anime.YearId;
            vm.SubId = Anime.SubId;
            // vm.CategoryIds = Anime.CategoryIds;
            if ((Anime.CategoryIds != null) && (Anime.CategoryIds.Count>0))
            {
                foreach (var item in Anime.CategoryIds)
                {
                    vm.CategoryIds += item + ",";
                }
                vm.CategoryIds=vm.CategoryIds.Remove(vm.CategoryIds.Length - 1);
            }
            return vm;
        }
    }
}
