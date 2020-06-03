using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Utilities.DTOs;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface IEpisodeService
    {

        int Add(EpisodeViewModel ep);

        void Update(EpisodeViewModel ep);

        void Delete(int id);

        Task<List<EpisodeViewModel>> GetAllWithAnimeId(int animeId);
        EpisodeViewModel GetById(int id);
        string GetAnimeName(int AnimeId);
        PagedResult<EpisodeViewModel>  GetAllPaging(int animeId, string keyword,int  page, int pageSize);


    }
}
